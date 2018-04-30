# Pdf-Digital-Signature 


try
{
	PDFSignServiceClient PDFSignClient = new PDFSignServiceClient();
	ret_data = PDFSignClient.GetSignedPDF(data);
}
catch (Exception ex) {
	throw new Exception(String.Format("PDF Signing Error.Error details:{0}",ex.ToString()));
}
