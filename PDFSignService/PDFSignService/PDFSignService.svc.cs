// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDFSignService.cs" email="Moinul Islam<moinul39.iit@gmail.com>">
//   Copyright @ 2016
// </copyright>
// <summary>
//   The PDFSignService.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SynesisIT.PDFSign;
using System.Configuration;
using PDFSignService.Helper;
using System.Web;
using System.IO;
using System.Reflection;
using System.Web.Hosting;
using SynesisIT.Infrastructure.Logger;

namespace PDFSignService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PDFSignService" in code, svc and config file together.
    public class PDFSignService : IPDFSignService
    {
        private ILogger _logger;

        public PDFSignService() {
            _logger = new Logger();
        }
        //public byte[] GetSignedPDF(byte[] data)
        //{
        //    throw new NotImplementedException();
        //}

        //public byte[] GetSignedPDF(byte[] data)
        //{
        //    PDFSign pdfSign = new PDFSign();
        //    string reason = ConfigurationManager.AppSettings["SIGN_REASON"];
        //    string location = ConfigurationManager.AppSettings["SIGN_LOCATION"];
        //    return pdfSign.sign(data, reason, location);
        //}
        public byte[] GetSignedPDF(byte[] data, SignInfo signInfo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     The method Get Signed PDF.
        /// </summary>
        /// <param name="data">
        /// The byte array[]
        /// </param>
        /// <returns>
        ///     The <see cref="byte[]" />.
        /// </returns>
        public byte[] GetSignedPDF(byte[] data)
        {
            DateTime startTime= _logger.MethodTraceStartTime();
            PDFSign pdfSign = Const.pdfSignPool.Rent() as PDFSign;
            if (Const.certificateInfo==null)
            {
                try
                {
                    CertificateInfo certificateInfo = Const.certificateInfo = new CertificateInfo();
                    string reason = ConfigurationManager.AppSettings["SIGN_REASON"];
                    _logger.WriteDebug(String.Format("Reason :{0}", reason));
                    string location = ConfigurationManager.AppSettings["SIGN_LOCATION"];
                    _logger.WriteDebug(String.Format("Location :{0}", location));
                    string password = ConfigurationManager.AppSettings["PASSWORD"];
                    _logger.WriteDebug(String.Format("Password :{0}", password));
                    //string certificatePath = HttpContext.Current.Server.MapPath("~")+ConfigurationManager.AppSettings["CERTIFICATE_PATH"];
                    string certificatePath = ConfigurationManager.AppSettings["CERTIFICATE_PATH"];
                    _logger.WriteDebug(String.Format("Certificate Path :{0}", certificatePath));
                    //certificatePath =HttpContext.Current.Server.MapPath("~")+certificatePath;
                    certificatePath = HostingEnvironment.ApplicationPhysicalPath + certificatePath;
                    _logger.WriteDebug(String.Format("Final Certificate Path :{0}", certificatePath));
                    certificateInfo.Location = location;
                    certificateInfo.Password = password;
                    certificateInfo.Reason = reason;
                    certificateInfo.CertificatePath = certificatePath;
                    if (!String.IsNullOrWhiteSpace(certificateInfo.CertificatePath) || !String.IsNullOrWhiteSpace(certificateInfo.Password))
                    {
                        certificateInfo.LoadCertificate();
                    }

                    Const.certificateInfo = certificateInfo;
                }
                catch (Exception ex) {
                    Const.certificateInfo = null;
                    _logger.WriteError(ex);
                    throw;
                }
                
            }
            
            //return pdfSign.sign(data, Const.certificateInfo.r, signInfo.location);
            var pdf=pdfSign.sign(data, Const.certificateInfo.Pkcs12Store, Const.certificateInfo.Password, Const.certificateInfo.Reason, Const.certificateInfo.Location, DateTime.Now);
            Const.pdfSignPool.Return(pdfSign);

            _logger.MethodTraceEnd(startTime);

            return pdf;

        }

        //public byte[] GetSignedPDF(string data)
        //{
        //    throw new NotImplementedException();
        //}

        //public byte[] GetSignedPDF(string data, SignInfo signInfo)
        //{
        //    return GetSignedPDF(Encoding.UTF8.GetBytes(data), signInfo);
        //}

        
    }
}
