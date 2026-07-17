public class SlackNotifierDecorator extends NotifierDecorator {

    public SlackNotifierDecorator(Notifier notifier) {
        super(notifier);
    }

    @Override
    public void send(String message) {       
        wrappedNotifier.send(message);        
        System.out.println("Sending Slack message: " + message);
    }
}
