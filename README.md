# Pdf-Digital-Signature 

Digital Certificates are used for secure communication between the two parties. In digital certification, we ensure that the people, who are using our apps or Services are securely communicating with each other and those people can be the individual consumers or businesses.

In Digital Certification, we use both Hashing and Asymmetric encryption to create the digital signatures. 

After encrypting the hash of data, we obtain a digital signature later, which is used for verification for the data.

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
