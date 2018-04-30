using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SynesisIT.PDFSignature
{
    public interface IPDFSign
    {
        byte[] GetSignedPDF(byte[] data);
        byte[] GetSignedPDF(byte[] data,string signaturePath);
        byte[] GetSignedPDF(String data);
        byte[] GetSignedPDF(String data, string signaturePath);
    }
}
