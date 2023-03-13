using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizationOfConsumerProducer2try
{
    public static class CommonData
    {
        private static int _maxQueueLength = 10;
        private static Queue<int>[] tResults = { new(), new(), new() };
        private static object locker = new();

        public delegate void EventHandler(object sender, EventArgs e);
        public static event EventHandler Got;

        public static void RaiseEvent()
        {
            Got?.Invoke(null, EventArgs.Empty);
        }

        public static void Put(int index, int value)
        {
            if (index >= 0 && index < tResults.Length)
            {
                lock (locker)
                {
                    while (tResults[index].Count >= _maxQueueLength)
                    {
                        Console.WriteLine($"Producer {index}: Место занято. Значение еще не получено Consumer.");
                        Monitor.Wait(locker);
                    }
                    Console.WriteLine($"Producer {index}: Добавление результата: {value}.");
                    tResults[index].Enqueue(value);
                    Monitor.PulseAll(locker);
                }
            }
        }

        public static int[] Get()
        {
            lock (locker)
            {
                while (!tResults.All(value => value.Count > 0))
                {
                    Console.WriteLine("Consumer: Данные еще не готовы. Ожидаем...");
                    Monitor.Wait(locker);
                }
                Console.WriteLine("Consumer: Данные готовы. Получаем...");
                var res = new[] { tResults[0].Dequeue(), tResults[1].Dequeue(), tResults[2].Dequeue() };
                Thread.Sleep(1000);
                RaiseEvent();
                Console.WriteLine("Consumer: Сигнализируем Producer об освобождении места");
                Monitor.PulseAll(locker);
                return res;
            }
        }
    }
}
