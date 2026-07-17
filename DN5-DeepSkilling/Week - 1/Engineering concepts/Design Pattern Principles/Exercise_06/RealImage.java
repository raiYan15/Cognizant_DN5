public class RealImage implements Image {

    private String filename;

    public RealImage(String filename) {
        this.filename = filename;
        // Loading happens when the object is created (expensive operation)
        loadFromServer();
    }

    // Simulates loading an image from a remote server
    private void loadFromServer() {
        System.out.println("Loading image from server: " + filename);
    }

    @Override
    public void display() {
        System.out.println("Displaying: " + filename);
    }
}
