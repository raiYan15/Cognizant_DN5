// Factory Method Pattern - Test / Entry Point
public class FactoryMethodTest
{
    public static void Main(string[] args)
    {
        // Create and open a Word document using WordDocumentFactory
        DocumentFactory wordFactory = new WordDocumentFactory();
        IDocument wordDoc = wordFactory.CreateDocument();
        wordDoc.Open();

        // Create and open a PDF document using PdfDocumentFactory
        DocumentFactory pdfFactory = new PdfDocumentFactory();
        IDocument pdfDoc = pdfFactory.CreateDocument();
        pdfDoc.Open();

        // Create and open an Excel document using ExcelDocumentFactory
        DocumentFactory excelFactory = new ExcelDocumentFactory();
        IDocument excelDoc = excelFactory.CreateDocument();
        excelDoc.Open();
    }
}
