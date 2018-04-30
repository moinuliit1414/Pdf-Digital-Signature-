using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SynesisIT.PDFSign;
using SynesisIT.PDFSign.Helper;

namespace PDFSignService.Helper
{
    public class Const
    {
        public static ObjectPool<PDFSign> pdfSignPool = new ObjectPool<PDFSign>();
        public static CertificateInfo certificateInfo;
    }
}