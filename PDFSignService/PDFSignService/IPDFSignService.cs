// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPDFSignService.cs" email="Moinul Islam<moinul39.iit@gmail.com>">
//   Copyright @ 2016
// </copyright>
// <summary>
//   The PDFSignService Interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PDFSignService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPDFSignService" in both code and config file together.
    [ServiceContract]
    public interface IPDFSignService
    {
        //[OperationContract]
        //byte[] GetSignedPDF(byte[] data);
        //[OperationContract]
        //byte[] GetSignedPDF(byte[] data, SignInfo signInfo);
        [OperationContract]
        byte[] GetSignedPDF(byte[] data);
        //[OperationContract]
        //byte[] GetSignedPDF(String data);
        //[OperationContract]
        //byte[] GetSignedPDF(String data, SignInfo signInfo);
    }
}
