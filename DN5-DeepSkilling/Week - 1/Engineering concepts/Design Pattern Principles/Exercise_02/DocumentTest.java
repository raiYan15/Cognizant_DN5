public class DocumentTest {
    public static void main(String[] args) {
        DocumentFactory wordFactory  = new WordDocumentFactory();
        DocumentFactory pdfFactory   = new PdfDocumentFactory();
        DocumentFactory excelFactory = new ExcelDocumentFactory();
        System.out.println("=== Document Management System ===");
        wordFactory.openDocument();
        pdfFactory.openDocument();
        excelFactory.openDocument();
    }
}
