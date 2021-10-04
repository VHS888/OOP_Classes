using System;

namespace ConsoleApp6
{
    class Train
    {
        private string model_of_train;
        private float temperature_of_engine;
        private uint type_of_train; // 0-Freight train 1-Passenger train, 2-Locomotive Train
        private bool isEngineOn;
        private readonly int max_capacity_of_wagon = 68;
        private decimal max_capacity_of_train;
        private int number_of_wagons;
        private float minT, maxT;
        public Train()
        {
            model_of_train = "M62";
            minT = 140;
            maxT = 180;
            temperature_of_engine = minT;
            number_of_wagons = 1;
            isEngineOn = false;
            this.max_capacity_of_train = number_of_wagons * max_capacity_of_wagon;
        }
        public Train(string model_of_train, float minT, float maxT)
        {
            this.model_of_train = model_of_train;
            if (minT > maxT)
            {
                float tmp = minT;
                minT = maxT;
                maxT = tmp;
            }
            this.minT = minT;
            this.maxT = maxT;
            temperature_of_engine = minT;
        }
        public Train(decimal max_capacity_of_train, float minT, float maxT, string model_of_train, uint type_of_train) : this(model_of_train, minT, maxT)
        {
            this.max_capacity_of_train = max_capacity_of_train;
            this.type_of_train = type_of_train;
        }
        public Train(string model_of_train, float minT, float maxT, int number_of_wagons, uint type_of_train) : this(model_of_train, minT, maxT)
        {
            this.type_of_train = type_of_train;
            this.number_of_wagons = number_of_wagons;
            this.max_capacity_of_train = number_of_wagons * max_capacity_of_wagon;
        }
        public float GetTemp()
        {
            return temperature_of_engine;
        }
        public int GetWagons()
        {
            return number_of_wagons;
        }

        public void SetType(uint type_of_train)
        {
            if (type_of_train >= 0 && type_of_train <= 3)
                this.type_of_train = type_of_train;
        }
        public void SetMaxCapOfTrain(int number_of_wagons)
		{
            this.number_of_wagons = number_of_wagons;
            this.max_capacity_of_train = number_of_wagons * max_capacity_of_wagon;
        }
        public void StartEngine()
        {
            if (this.isEngineOn == false)
            {
                this.isEngineOn = true;
            }
        }

        public void IncreaseTemperature()
        {
            if (temperature_of_engine < maxT)
                temperature_of_engine += 20F;
        }
        public void DecreaseTemperature()
        {
            if (temperature_of_engine > minT)
                temperature_of_engine -= 20F;
        }
        public void ShowInformation()
        {
            Console.WriteLine($"Model: {model_of_train}\n" +
                              $"Temperature of engine: {temperature_of_engine}\n" +
                              $"Number of wagons:  {number_of_wagons}\n" +
                              $"Maximal capacity of train: {max_capacity_of_train}"
            );
            if (isEngineOn)
            {
                Console.WriteLine("Engine is working");
            }
            else
            {
                Console.WriteLine("Engine isn't working");
            }
            switch (type_of_train)
            {
                case 0: Console.Write("Freight train\n"); break;
                case 1: Console.Write("Passenger train\n"); break;
                case 2: Console.Write("Locomotive Train\n"); break;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Train TR1 = new Train();
                Train TR2 = new Train("B32", 121, 170);
                Train TR3 = new Train(1500, 122, 171, "A44", 2);
                Train TR4 = new Train("С31", 123, 172, 50, 1);
                TR1.StartEngine();
                TR1.IncreaseTemperature();
                Console.WriteLine($"Current Temperature: {TR1.GetTemp()} C");
                TR2.SetMaxCapOfTrain(50);
                TR2.DecreaseTemperature();
                TR2.DecreaseTemperature();
                TR2.ShowInformation();
                TR3.SetMaxCapOfTrain(10);
                Console.WriteLine($"Numbers of wagons: {TR3.GetWagons()}");
                TR4.SetType(2);
                TR4.ShowInformation();
            }
        }
    }
}
