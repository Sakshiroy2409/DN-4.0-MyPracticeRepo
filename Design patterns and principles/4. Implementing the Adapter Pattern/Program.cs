using System;

namespace AdapterPatternExample
{
    
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    
    public class PayPalGateway
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine($"Payment of ${amount} processed through PayPal.");
        }
    }

    
    public class StripeGateway
    {
        public void Charge(decimal money)
        {
            Console.WriteLine($"Charged ${money} using Stripe.");
        }
    }

    
    public class PayPalAdapter : IPaymentProcessor
    {
        private readonly PayPalGateway _payPal;

        public PayPalAdapter(PayPalGateway payPal)
        {
            _payPal = payPal;
        }

        public void ProcessPayment(decimal amount)
        {
            
            _payPal.MakePayment((double)amount);
        }
    }

    
    public class StripeAdapter : IPaymentProcessor
    {
        private readonly StripeGateway _stripe;

        public StripeAdapter(StripeGateway stripe)
        {
            _stripe = stripe;
        }

        public void ProcessPayment(decimal amount)
        {
            _stripe.Charge(amount);
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            
            IPaymentProcessor payPalPayment = new PayPalAdapter(new PayPalGateway());
            payPalPayment.ProcessPayment(150.00m);

            
            IPaymentProcessor stripePayment = new StripeAdapter(new StripeGateway());
            stripePayment.ProcessPayment(200.00m);
        }
    }
}