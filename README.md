# Pdf-Digital-Signature 

Step 1. run this project.
Step 2.Create another project
Step 1. Add service reference named PDFSignServiceClient()

string path = @"C:\Users\Moinul\Desktop\HP\Template.pdf";
byte[] data = System.IO.File.ReadAllBytes(path);
byte[] ret_data=null;
try
{
	PDFSignServiceClient PDFSignClient = new PDFSignServiceClient();
	ret_data = PDFSignClient.GetSignedPDF(data);
}
catch (Exception ex) {
	throw new Exception(String.Format("PDF Signing Error.Error details:{0}",ex.ToString()));
}
