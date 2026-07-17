public class ProxyImage implements Image {

    private String filename;
    private RealImage realImage;  // cached reference

    public ProxyImage(String filename) {
        this.filename = filename;
        // Note: we do NOT load the image here (lazy initialization)
    }

    @Override
    public void display() {
        // Load only if not already loaded (lazy init + caching)
        if (realImage == null) {
            realImage = new RealImage(filename);
        }
        realImage.display();
    }
}
