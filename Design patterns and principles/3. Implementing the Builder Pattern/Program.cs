using System;

namespace BuilderPatternExample
{
    
    public class Computer
    {
        
        public string CPU { get; }
        public string RAM { get; }
        public string Storage { get; }
        public string GraphicsCard { get; }

        
        private Computer(Builder builder)
        {
            CPU = builder.CPU;
            RAM = builder.RAM;
            Storage = builder.Storage;
            GraphicsCard = builder.GraphicsCard;
        }

        public override string ToString()
        {
            return $"Computer [CPU={CPU}, RAM={RAM}, Storage={Storage}, GraphicsCard={GraphicsCard}]";
        }

        
        public class Builder
        {
            public string CPU { get; private set; }
            public string RAM { get; private set; }
            public string Storage { get; private set; }
            public string GraphicsCard { get; private set; }

            public Builder SetCPU(string cpu)
            {
                CPU = cpu;
                return this;
            }

            public Builder SetRAM(string ram)
            {
                RAM = ram;
                return this;
            }

            public Builder SetStorage(string storage)
            {
                Storage = storage;
                return this;
            }

            public Builder SetGraphicsCard(string graphicsCard)
            {
                GraphicsCard = graphicsCard;
                return this;
            }

            
            public Computer Build()
            {
                return new Computer(this);
            }
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            
            var gamingPC = new Computer.Builder()
                .SetCPU("Intel i9")
                .SetRAM("32GB")
                .SetStorage("1TB SSD")
                .SetGraphicsCard("NVIDIA RTX 4090")
                .Build();

            
            var officePC = new Computer.Builder()
                .SetCPU("Intel i5")
                .SetRAM("16GB")
                .SetStorage("512GB SSD")
                .Build(); 

            Console.WriteLine(gamingPC);
            Console.WriteLine(officePC);
        }
    }
}