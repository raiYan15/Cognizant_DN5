public class PaymentContext {
    private PaymentStrategy paymentStrategy;
    public void setPaymentStrategy(PaymentStrategy strategy) {
        this.paymentStrategy = strategy;
    }
    public void executePayment(double amount) {
        if (paymentStrategy == null) {
            System.out.println("No payment strategy set.");
            return;
        }
        paymentStrategy.pay(amount);
    }
}
