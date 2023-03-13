using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizationOfConsumerProducer2try
{
    public class Producer
    {
        private PrintedQueue pq;
        private const int maxCount = 10;

        private int num;
        public int Num => num;

        public Producer(int num, Control panel)
        {
            this.num = num;
            pq = new PrintedQueue(panel);
            CommonData.Got += HandleEvent;
        }

        private void HandleEvent(object sender, EventArgs e)
        {
            pq.Dequeue();
        }

        public void Start()
        {
            var t = new Thread(() =>
            {
                var iter = 0;
                while (iter++ < maxCount)
                {
                    var r = new Random();
                    switch (num)
                    {
                        case 0:
                            Thread.Sleep(r.Next(500, 1000));
                            break;
                        case 1:
                            Thread.Sleep(r.Next(2000, 3000));
                            break;
                        case 2:
                            Thread.Sleep(r.Next(3000, 7000));
                            break;
                    }
                    
                    var result = r.Next(50,255);

                    switch (num)
                    {
                        case 0:
                            pq.Enqueue(result, 0, 0);
                            break;
                        case 1:
                            pq.Enqueue(0, result, 0);
                            break;
                        case 2:
                            pq.Enqueue(0, 0, result);
                            break;
                    }
                    //Console.WriteLine($"Producer №{num}: {result}");

                    CommonData.Put(num, result);
                }
            });
            t.IsBackground = true;
            t.Start();
        }

    }
}
