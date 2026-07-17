public class LoggerTest {
    public static void main(String[] args) {
        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();
        if (logger1 == logger2) {
            System.out.println("Same instance - Singleton is working correctly!");
        } else {
            System.out.println("Different instances - Singleton is NOT working.");
        }
        logger1.log("Application started.");
        logger2.log("User logged in.");
        logger1.log("Application finished.");
    }
}
