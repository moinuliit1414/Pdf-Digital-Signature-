// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPDFSign.cs" email="Moinul Islam<moinul39.iit@gmail.com>">
//   Copyright @ 2016
// </copyright>
// <summary>
//   The PDFSign Interface..
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace PDFSignService
{
    [ServiceContract]
    public interface IPDFSign
    {
        
        [OperationContract]
        byte[] GetSignedPDF(byte[] data);
        [OperationContract]
        byte[] GetSignedPDF(byte[] data, SignInfo signInfo);
        [OperationContract]
        byte[] GetSignedPDF(String data);
        [OperationContract]
        byte[] GetSignedPDF(String data, SignInfo signInfo);
    }
}
