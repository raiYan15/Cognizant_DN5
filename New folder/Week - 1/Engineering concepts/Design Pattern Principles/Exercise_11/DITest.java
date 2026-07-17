public class DITest {

    public static void main(String[] args) {

        System.out.println("=== Dependency Injection - Customer Management ===\n");
        CustomerRepository repository = new CustomerRepositoryImpl();
        CustomerService service = new CustomerService(repository);
        service.findCustomer(1);
        service.findCustomer(2);
        service.findCustomer(3);
        service.findCustomer(99);
        System.out.println("\nDependency was injected through the constructor, not created inside CustomerService.");
    }
}
