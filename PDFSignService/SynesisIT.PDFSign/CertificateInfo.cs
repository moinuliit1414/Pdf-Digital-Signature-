// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CertificateInfo.cs" email="Moinul Islam<moinul39.iit@gmail.com>">
//   Copyright @ 2018
// </copyright>
// <summary>
//   The Certificate Info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Org.BouncyCastle.Pkcs;
using System.IO;

namespace SynesisIT.PDFSign
{
    public class CertificateInfo
    {

        private Pkcs12Store _pkcs12Store;
        private string _certificatePath;

        public string Password {get;set;}
        public string Reason { get; set; }
        public string Location { get; set; }
        public Pkcs12Store Pkcs12Store { get { return _pkcs12Store; } set { _pkcs12Store = value; } }
        public string CertificatePath{ get; set; }

        /// <summary>
        ///     The method Load Certificate.
        /// </summary>
        /// <param name="password">
        /// The password of certificate.
        /// </param>
        /// <param name="certificatePath">
        /// physical location of certificate.
        /// </param>
        public void LoadCertificate(string password, string certificatePath)
        {
            if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(certificatePath))
            {
                throw new Exception("proparty of CertificatePath and Password should not be null");
            }
            try
            {
                if (!File.Exists(certificatePath))
                {
                    throw new FileNotFoundException();
                }


                _pkcs12Store = new Pkcs12Store((Stream)new FileStream(certificatePath, FileMode.Open, FileAccess.Read), Password.ToCharArray());

            }
            catch (FileNotFoundException fnfex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Fi"+ex.ToString());
            }
        }

        /// <summary>
        ///     The method Load Certificate.
        /// </summary>
        public void LoadCertificate(){
            if(String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(CertificatePath)){
                throw new Exception("proparty of CertificatePath and Password should not be null");
            }
            try{
                    if(!File.Exists(CertificatePath)){
                        throw new FileNotFoundException(); 
                    }
                    
                    
                    _pkcs12Store = new Pkcs12Store((Stream)new FileStream(CertificatePath, FileMode.Open, FileAccess.Read), Password.ToCharArray());
                   
                }catch(FileNotFoundException fnfex){
                    throw;
                }
                catch(Exception ex){
                    throw new Exception("Fi");
                }
        }
    }
}
