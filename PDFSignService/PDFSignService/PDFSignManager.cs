// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDFSignManager.cs" email="Moinul Islam<moinul39.iit@gmail.com>">
//   Copyright @ 2016
// </copyright>
// <summary>
//   The PDF Sign Manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using SynesisIT.PDFSign;

namespace PDFSignService
{
    public class PDFSignManager:IPDFSign
    {

        public byte[] GetSignedPDF(byte[] data)
        {
            String signaturePath = ConfigurationManager.AppSettings["BACK_IMG_FLOAT_X"];
            return GetSignedPDF(data, signaturePath);

        }

        public byte[] GetSignedPDF(byte[] data, string signaturePath)
        {
            throw new NotImplementedException();
            
        }

        public byte[] GetSignedPDF(string data)
        {
            throw new NotImplementedException();
        }

        public byte[] GetSignedPDF(string data, string signaturePath)
        {
            throw new NotImplementedException();
        }


        public byte[] GetSignedPDF(byte[] data, SignInfo signInfo)
        {
            PDFSign pdfSign = new PDFSign();
            return pdfSign.sign(data, signInfo.Reason, signInfo.location);
        }

        public byte[] GetSignedPDF(string data, SignInfo signInfo)
        {
            throw new NotImplementedException(); 
        }
    }
}