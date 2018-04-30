// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDFSign.cs" email="Moinul Islam<moinul39.iit@gmail.com>">
//   Copyright @ 2018
// </copyright>
// <summary>
//   The PDF Sign.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Crypto;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using Org.BouncyCastle.X509;
using System.Reflection;
using System.Configuration;

namespace SynesisIT.PDFSign
{
    public class PDFSign
    {
        private byte[] _result;
        private string _certificatePath;
        private string _password;
        private string _reason;
        private string _location;
        //public bool _executed=false;
        //private Pkcs12Store _pkcs12Store;

        public byte[] sign(byte[] input, string password, string reason, string location, DateTime signDate)
        {
            string certificatePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), ConfigurationManager.AppSettings["CERTIFICATE_PATH"]); ;
            this._certificatePath = certificatePath;
            Pkcs12Store pkcs12Store = new Pkcs12Store((Stream)new FileStream(_certificatePath, FileMode.Open, FileAccess.Read), password.ToCharArray());

            return sign(input, pkcs12Store, password, reason, location, signDate);
        }

        public byte[] sign(byte[] input, string reason, string location, DateTime signDate)
        {
            string password = ConfigurationManager.AppSettings["PASSWORD"];
            this._password = password;
            return sign(input, password, reason, location, signDate);
        }

        public byte[] sign(byte[] input, string reason, string location)
        {
            this._location = location;
            this._reason = reason;
            return sign(input, reason, location, DateTime.Now);
        }

        //public byte[] sign(byte[] input)
        //{
        //    return sign(input, this._pkcs12Store,this._password, this._reason, this._location, DateTime.Now);
        //}
        
        public byte[] sign(byte[] input, CertificateInfo certificateInfo)
        {
            return sign(input, certificateInfo.Pkcs12Store, certificateInfo.Password, certificateInfo.Reason, certificateInfo.Location, DateTime.Now);
        }

        /// <summary>
        ///     The method Sign Pdf.
        /// </summary>
        /// <param name="input">
        /// The pdf to signed.
        /// </param>
        /// <param name="_pkcs12Store">
        /// Pkcs12Store private key.
        /// </param>
        /// <param name="password">
        /// password of Pkcs12Store key.
        /// </param>
        /// <param name="reason">
        /// reason for digital signature.
        /// </param>
        ///<param name="location">
        /// signing location.
        /// </param>
        /// ///<param name="signDate">
        /// signing time.
        /// </param>
        /// <returns>
        ///     The <see cref="byte[]" />.
        /// </returns>
        public byte[] sign(byte[] input, Pkcs12Store _pkcs12Store, string password, string reason, string location, DateTime signDate)
        {
            //_pkcs12Store = pkcs12Store;
            Pkcs12Store pkcs12Store = _pkcs12Store;
            //Pkcs12Store pkcs12Store = new Pkcs12Store((Stream)new FileStream(certificatePath, FileMode.Open, FileAccess.Read), password.ToCharArray());
            string str6 = (string)null;
            foreach (string aliase in pkcs12Store.Aliases)
            {
                if (pkcs12Store.IsKeyEntry(aliase))
                    str6 = aliase;
            }

            AsymmetricKeyParameter key = pkcs12Store.GetKey(str6).Key;
            PdfReader pdfReader = new PdfReader(input);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (PdfStamper signature = PdfStamper.CreateSignature(pdfReader, (Stream)memoryStream, char.MinValue))
                {
                    PdfSignatureAppearance signatureAppearance = signature.SignatureAppearance;
                    signatureAppearance.Reason = reason;
                    signatureAppearance.Location = location;
                    signatureAppearance.SignDate = signDate;
                    signatureAppearance.CertificationLevel = 1;
                    IExternalSignature iexternalSignature = (IExternalSignature)new PrivateKeySignature((ICipherParameters)key, "SHA-256");
                    MakeSignature.SignDetached(signatureAppearance, iexternalSignature, (ICollection<X509Certificate>)new X509Certificate[1]
              {
                //pkcs12Store.GetCertificate(str6).get_Certificate()
                pkcs12Store.GetCertificate(str6).Certificate
              }, (ICollection<ICrlClient>)null, (IOcspClient)null, (ITSAClient)null, 0, (CryptoStandard)0);
                    signature.Close();
                }
                this._result = memoryStream.ToArray();
            }
            return this._result;
        }
      
    }
}
