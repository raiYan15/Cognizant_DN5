public class CommandTest {

    public static void main(String[] args) {

        System.out.println("=== Command Pattern - Home Automation System ===\n");
        Light livingRoomLight = new Light("Living Room");
        Light bedroomLight    = new Light("Bedroom");
        Command lightOn   = new LightOnCommand(livingRoomLight);
        Command lightOff  = new LightOffCommand(livingRoomLight);
        Command bedOn     = new LightOnCommand(bedroomLight);
        Command bedOff    = new LightOffCommand(bedroomLight);
        RemoteControl remote = new RemoteControl();
        remote.setCommand(lightOn);
        remote.pressButton();
        remote.setCommand(lightOff);
        remote.pressButton();
        remote.setCommand(bedOn);
        remote.pressButton();
        remote.setCommand(bedOff);
        remote.pressButton();
    }
}
