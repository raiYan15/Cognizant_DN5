public class Computer {
    private String cpu;
    private String ram;
    private String storage;
    private String graphicsCard;
    private boolean hasBluetooth;
    private Computer(Builder builder) {
        this.cpu = builder.cpu;
        this.ram = builder.ram;
        this.storage = builder.storage;
        this.graphicsCard = builder.graphicsCard;
        this.hasBluetooth = builder.hasBluetooth;
    }
    public void showSpecs() {
        System.out.println("=== Computer Specs ===");
        System.out.println("CPU          : " + cpu);
        System.out.println("RAM          : " + ram);
        System.out.println("Storage      : " + storage);
        System.out.println("Graphics Card: " + (graphicsCard != null ? graphicsCard : "None"));
        System.out.println("Bluetooth    : " + (hasBluetooth ? "Yes" : "No"));
        System.out.println("======================");
    }
    public static class Builder {
        private String cpu;
        private String ram;
        private String storage;
        private String graphicsCard;
        private boolean hasBluetooth;
        public Builder(String cpu, String ram, String storage) {
            this.cpu = cpu;
            this.ram = ram;
            this.storage = storage;
        }
        public Builder graphicsCard(String graphicsCard) {
            this.graphicsCard = graphicsCard;
            return this;
        }
        public Builder bluetooth(boolean hasBluetooth) {
            this.hasBluetooth = hasBluetooth;
            return this;
        }        
        public Computer build() {
            return new Computer(this);
        }
    }
}
