public class SMSNotifierDecorator extends NotifierDecorator {

    public SMSNotifierDecorator(Notifier notifier) {
        super(notifier);
    }

    @Override
    public void send(String message) {        
        wrappedNotifier.send(message);        
        System.out.println("Sending SMS: " + message);
    }
}
