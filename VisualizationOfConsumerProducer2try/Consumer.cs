using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizationOfConsumerProducer2try
{
    public class Consumer
    {
        private PrintedQueue pq;
        public Consumer(Control panel)
        {
            pq = new PrintedQueue(panel);
            
        }
        public void Start()
        {
            var t = new Thread(() =>
            {
                while (true)
                {
                    var tResults = CommonData.Get();
                    var r = new Random();
                    pq.Enqueue(tResults[0], tResults[1], tResults[2]);
                    Thread.Sleep(r.Next(5000, 10000));
                }
            });
            t.IsBackground = true;
            t.Start();
        }

    }
}
