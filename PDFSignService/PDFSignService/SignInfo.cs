// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SignInfo.cs" email="Moinul Islam<moinul39.iit@gmail.com>">
//   Copyright @ 2016
// </copyright>
// <summary>
//   The SignInfo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PDFSignService
{
    [DataContract]
    public class SignInfo
    {
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public string location { get; set; }
        [DataMember]
        public DateTime SignDate { get; set; }
    }
}