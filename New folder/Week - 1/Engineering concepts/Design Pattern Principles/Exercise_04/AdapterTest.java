public class AdapterTest {

    public static void main(String[] args) {

        System.out.println("=== Adapter Pattern - Payment Gateway System ===\n");
        PaymentProcessor paypal = new PayPalAdapter(new PayPalGateway());
        System.out.print("PayPal: ");
        paypal.processPayment(150.00);
        PaymentProcessor stripe = new StripeAdapter(new StripeGateway());
        System.out.print("Stripe: ");
        stripe.processPayment(250.50);

        System.out.println("\nBoth gateways used via the same PaymentProcessor interface!");
    }
}
