using System;

namespace DependencyInjectionExample
{
    
    public interface ICustomerRepository
    {
        string FindCustomerById(int id);
    }

    
    public class CustomerRepositoryImpl : ICustomerRepository
    {
        public string FindCustomerById(int id)
        {
            
            return $"Customer with ID {id} found: John Doe";
        }
    }

    
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void GetCustomer(int id)
        {
            string result = _customerRepository.FindCustomerById(id);
            Console.WriteLine(result);
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            
            ICustomerRepository repository = new CustomerRepositoryImpl();
            CustomerService service = new CustomerService(repository);

            
            service.GetCustomer(101);
        }
    }
}