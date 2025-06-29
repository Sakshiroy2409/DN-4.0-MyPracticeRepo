using System;
using System.Collections.Generic;

namespace ObserverPatternExample
{
    
    public interface IStock
    {
        void RegisterObserver(IObserver observer);
        void DeregisterObserver(IObserver observer);
        void NotifyObservers();
    }

    
    public interface IObserver
    {
        void Update(string stockName, double price);
    }

    
    public class StockMarket : IStock
    {
        private List<IObserver> _observers = new List<IObserver>();
        private string _stockName;
        private double _price;

        public StockMarket(string stockName)
        {
            _stockName = stockName;
        }

        public void SetPrice(double newPrice)
        {
            _price = newPrice;
            Console.WriteLine($"\n{_stockName} price updated to {_price:C}");
            NotifyObservers();
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void DeregisterObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_stockName, _price);
            }
        }
    }

    
    public class MobileApp : IObserver
    {
        private string _appName;

        public MobileApp(string appName)
        {
            _appName = appName;
        }

        public void Update(string stockName, double price)
        {
            Console.WriteLine($"[MobileApp: {_appName}] {stockName} is now {price:C}");
        }
    }

    
    public class WebApp : IObserver
    {
        private string _webName;

        public WebApp(string webName)
        {
            _webName = webName;
        }

        public void Update(string stockName, double price)
        {
            Console.WriteLine($"[WebApp: {_webName}] {stockName} is now {price:C}");
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            
            StockMarket stock = new StockMarket("ACME Corp");

            
            IObserver mobileUser = new MobileApp("StockTracker Mobile");
            IObserver webUser = new WebApp("StockDashboard Web");

            
            stock.RegisterObserver(mobileUser);
            stock.RegisterObserver(webUser);

            
            stock.SetPrice(100.50);
            stock.SetPrice(102.75);

            
            stock.DeregisterObserver(mobileUser);

            
            stock.SetPrice(105.30);
        }
    }
}