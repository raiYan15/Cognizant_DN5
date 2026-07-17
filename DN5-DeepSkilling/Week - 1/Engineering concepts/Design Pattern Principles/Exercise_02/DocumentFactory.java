public abstract class DocumentFactory {
    public abstract Document createDocument();
    public void openDocument() {
        Document doc = createDocument();
        doc.open();
    }
}
