public class CustomerRepositoryImpl implements CustomerRepository {

    @Override
    public String findCustomerById(int id) {
        switch (id) {
            case 1: return "Alice Johnson";
            case 2: return "Bob Smith";
            case 3: return "Charlie Brown";
            default: return null;
        }
    }
}
