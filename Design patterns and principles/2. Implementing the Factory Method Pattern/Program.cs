using System;

namespace FactoryMethodPatternExample
{
    
    public interface IDocument
    {
        void Open();
    }

    
    public class WordDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening a Word document.");
        }
    }

    public class PdfDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening a PDF document.");
        }
    }

    public class ExcelDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening an Excel document.");
        }
    }

    
    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }

    
    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }

    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }

    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            DocumentFactory factory;

            
            factory = new WordDocumentFactory();
            IDocument word = factory.CreateDocument();
            word.Open();  

            
            factory = new PdfDocumentFactory();
            IDocument pdf = factory.CreateDocument();
            pdf.Open();  

            
            factory = new ExcelDocumentFactory();
            IDocument excel = factory.CreateDocument();
            excel.Open();  
        }
    }
}