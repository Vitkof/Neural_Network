using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace NeuronNetwork
{
    class Program
    {
        public class Neuron
        {
            private decimal weight = 0.5m;
            private decimal smoothing = 0.0005m;

            public decimal ConvertData(decimal input)
            {
                return input * weight;
            }
            public decimal ReconvertData(decimal output)
            {
                return output / weight;
            }
            public void Train(decimal input, decimal expectRes)
            {
                int step = 0;
                DateTime t0 = DateTime.Now;
                decimal error;
                do
                {
                    step++;
                    var actual = ConvertData(input);
                    error = actual - expectRes;
                    var correction = -error / actual;
                    weight += (correction * smoothing);
                    Console.WriteLine($"Шаг: {step}, Неточность: {error}");
                }
                while (error > smoothing || error < -smoothing);
                TimeSpan interval = DateTime.Now.Subtract(t0);
                Console.WriteLine($"Обучение нейрона завершено!\n{interval.Seconds}.{interval.Milliseconds} sec.");
            }
        }
        static void Main(string[] args)
        {
            Neuron neur = new Neuron();
            Console.WriteLine($"Заложенный вероятносный вес: 0,5 (50 %)");
            Console.ReadKey();
            decimal km = 100;
            decimal mile = 62.14m;
            neur.Train(km, mile);
            Console.Write("Введите N км: ");
            int k = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"В {k} км {neur.ConvertData(k)} мили.");
            Console.Write("Введите N миль: ");
            int m = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"В {k} мил(-е,-ях) {neur.ReconvertData(k)} км.");

            Console.ReadKey();
        }
    }
}
