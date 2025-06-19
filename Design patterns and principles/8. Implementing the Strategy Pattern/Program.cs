using System;

namespace StrategyPatternExample
{
    
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    
    public class CreditCardPayment : IPaymentStrategy
    {
        private string _cardNumber;

        public CreditCardPayment(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using Credit Card ending with {_cardNumber.Substring(_cardNumber.Length - 4)}");
        }
    }

    
    public class PayPalPayment : IPaymentStrategy
    {
        private string _email;

        public PayPalPayment(string email)
        {
            _email = email;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount:C} using PayPal account: {_email}");
        }
    }

    
    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            _paymentStrategy = strategy;
        }

        public void ProcessPayment(decimal amount)
        {
            if (_paymentStrategy == null)
            {
                Console.WriteLine("No payment strategy selected.");
            }
            else
            {
                _paymentStrategy.Pay(amount);
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            PaymentContext paymentContext = new PaymentContext();

            
            paymentContext.SetPaymentStrategy(new CreditCardPayment("1234567890123456"));
            paymentContext.ProcessPayment(150.00m);

            
            paymentContext.SetPaymentStrategy(new PayPalPayment("user@example.com"));
            paymentContext.ProcessPayment(75.50m);
        }
    }
}