public class ProxyTest {

    public static void main(String[] args) {

        System.out.println("=== Proxy Pattern - Image Viewer ===\n");

        // Create proxy - image is NOT loaded yet
        Image photo1 = new ProxyImage("vacation_photo.jpg");
        Image photo2 = new ProxyImage("profile_picture.png");

        System.out.println("--- First call to photo1.display() ---");
        photo1.display();  // loads from server, then displays

        System.out.println("\n--- Second call to photo1.display() ---");
        photo1.display();  // uses cache, no server load

        System.out.println("\n--- First call to photo2.display() ---");
        photo2.display();  // loads from server (photo2 wasn't loaded yet)

        System.out.println("\n--- Second call to photo2.display() ---");
        photo2.display();  // uses cache
    }
}
