public class CustomerService {
    private CustomerRepository customerRepository;
    public CustomerService(CustomerRepository customerRepository) {
        this.customerRepository = customerRepository;
    }
    public void findCustomer(int id) {
        String customerName = customerRepository.findCustomerById(id);
        if (customerName != null) {
            System.out.println("Customer found: " + customerName + " (ID: " + id + ")");
        } else {
            System.out.println("No customer found with ID: " + id);
        }
    }
}
