
public class ComputerBuilderTest {

    public static void main(String[] args) {
        System.out.println("=== Builder Pattern - Computer Configurations ===\n");        
        Computer officePC = new Computer.Builder("Intel i3", "8GB", "256GB SSD")
                .build();
        System.out.println("Office PC:");
        officePC.showSpecs();
        Computer gamingPC = new Computer.Builder("Intel i9", "32GB", "1TB SSD")
                .graphicsCard("NVIDIA RTX 4080")
                .bluetooth(true)
                .build();
        System.out.println("\nGaming PC:");
        gamingPC.showSpecs();
        Computer workstation = new Computer.Builder("AMD Ryzen 7", "16GB", "512GB SSD")
                .bluetooth(true)
                .build();
        System.out.println("\nWorkstation:");
        workstation.showSpecs();
    }
}
