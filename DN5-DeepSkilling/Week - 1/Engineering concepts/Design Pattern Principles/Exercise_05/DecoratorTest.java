public class DecoratorTest {

    public static void main(String[] args) {
        System.out.println("=== Decorator Pattern - Notification System ===\n");
        System.out.println("--- Email Only ---");
        Notifier emailOnly = new EmailNotifier();
        emailOnly.send("Your order has been placed.");
        System.out.println("\n--- Email + SMS ---");
        Notifier emailAndSms = new SMSNotifierDecorator(new EmailNotifier());
        emailAndSms.send("Your order has been shipped.");
        System.out.println("\n--- Email + SMS + Slack ---");
        Notifier allChannels = new SlackNotifierDecorator(
                                   new SMSNotifierDecorator(
                                       new EmailNotifier()));
        allChannels.send("Payment confirmed!");
    }
}
