using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MangoPDFSign;
using MangoBridgeAPI;

namespace SynesisIT.PDFSignature
{
    public class PDFSignManager : IPDFSign
    {
        public byte[] GetSignedPDF(byte[] data)
        {
            String signaturePath = ConfigurationManager.AppSettings["BACK_IMG_FLOAT_X"];
            return GetSignedPDF(data, signaturePath);

        }

        public byte[] GetSignedPDF(byte[] data, string signaturePath)
        {
            throw new NotImplementedException();
            MangoPDFSign.Class1 obj1 = new MangoPDFSign.Class1();
            byte[] ret_data = obj1.mangosign(data, "");
            return ret_data;
        }

        public byte[] GetSignedPDF(string data)
        {
            throw new NotImplementedException();
        }

        public byte[] GetSignedPDF(string data, string signaturePath)
        {
            throw new NotImplementedException();
        }
    }
}
