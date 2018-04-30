using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SynesisIT.PDFSign;
using SynesisIT.PDFSign;
using System.IO;
using SynesisIT.PDFSign.Helper;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace PDFSignTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            string path = @"C:\Users\Moinul\Desktop\certificate\SignTemplate_1.pdf";
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            List<PDFSign> PDFSignList = new List<PDFSign>();
            PDFSign pdf = new PDFSign();
            //byte[] signbytes=new byte[1];
            ObjectPool<PDFSign> objectPool = new ObjectPool<PDFSign>();
            PDFSign a, a1, a2;

            a = objectPool.Rent() as PDFSign;
            //a1 = objectPool.Rent() as PDFSign;
            //a2 = objectPool.Rent() as PDFSign;

            //a._executed = true;
            //a1._executed = true;
            //a2._executed = true;

            //Thread t1 = new Thread(() =>
            //{
            //    Thread.Sleep(10000);
            //    a = objectPool.Rent() as PDFSign;
            //    Thread.Sleep(10000);
            //    a._executed = true;
            //    Thread.Sleep(10000);
            //});

            //Thread t2 = new Thread(() =>
            //{
            //    Thread.Sleep(10000);
            //    a1 = objectPool.Rent() as PDFSign;
            //    Thread.Sleep(10000);
            //    a1._executed = true;
            //    Thread.Sleep(10000);
            //});


            //t1.Start();
            //t2.Start();
            //Parallel.For(0, 100, (i, state) => { 
            //    //Console.WriteLine(i); if (i == 50) state.Stop(); 
            //    a = objectPool.Rent() as PDFSign;
            //    //if (objectPool.IsEmptyPool())
            //    if(!a._executed)
            //    {

            //        signbytes=a.sign(bytes, "This Document has been certified by National Board of Revenue", "Dhaka, Bangladesh");
            //    }
            //    else {

            //        signbytes=a.sign(bytes);
            //    }
            //    File.WriteAllBytes(@"C:\Users\Moinul\Desktop\HP\SignTemplate"+i+"_"+DateTime.Now.Minute+"_"+DateTime.Now.Millisecond+".pdf", signbytes);
            //});

            //int largest = arr[0];
            //Parallel.ForEach(Partitioner.Create(0, arr.Length), () => arr[0], (range, loop, subtotal)=>
            //{
            //    Your stuff
            //});
            //Parall for(int i=0; i <100; i++){
            //    var a = objectPool.Rent() as PDFSign;
            //    if (objectPool.IsEmptyPool())
            //    {

            //        signbytes=a.sign(bytes, "This Document has been certified by National Board of Revenue", "Dhaka, Bangladesh");
            //    }
            //    else {

            //        signbytes=a.sign(bytes);
            //    }
            //    File.WriteAllBytes(@"C:\Users\DELL\Desktop\HP\SignTemplate.pdf", signbytes);
            //}
            byte[] signbytes = pdf.sign(bytes, "This Document has been certified by Moinul For Test Purpose", "Dhaka, Bangladesh");
            //byte[] signbytes = pdf.mangosign(bytes, "\\Content\\PDF\\");
            File.WriteAllBytes(@"C:\Users\Moinul\Desktop\certificate\SignTemplate_sign.pdf", signbytes);
        }
    }
}
