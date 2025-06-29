using System;

namespace ProxyPatternExample
{
    
    public interface IImage
    {
        void Display();
    }

    
    public class RealImage : IImage
    {
        private string _fileName;

        public RealImage(string fileName)
        {
            _fileName = fileName;
            LoadFromRemoteServer();
        }

        private void LoadFromRemoteServer()
        {
            Console.WriteLine($"Loading image '{_fileName}' from remote server...");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying image '{_fileName}'");
        }
    }

    
    public class ProxyImage : IImage
    {
        private RealImage _realImage;
        private string _fileName;

        public ProxyImage(string fileName)
        {
            _fileName = fileName;
        }

        public void Display()
        {
            
            if (_realImage == null)
            {
                _realImage = new RealImage(_fileName);
            }
            _realImage.Display();
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            IImage image1 = new ProxyImage("nature_photo.jpg");
            IImage image2 = new ProxyImage("cityscape.png");

            
            image1.Display(); 

            
            image1.Display(); 

            
            image2.Display(); 
        }
    }
}