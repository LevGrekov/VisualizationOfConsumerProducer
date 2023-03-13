using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualizationOfConsumerProducer2try.VisualizationOfConsumeAndProduce;

namespace VisualizationOfConsumerProducer2try
{
    public class PrintedQueue
    {
        private Queue<Square> queue = new Queue<Square>();
        private int elementSize = 50;
        private int padding = 5;
        private Control queuePanel;

        public PrintedQueue(Control panel)
        {
            queuePanel = panel;
        }

        private void UpdateQueueVisualizer()
        {
            if (queuePanel.InvokeRequired)
            {
                queuePanel.Invoke(new MethodInvoker(() =>
                {
                    queuePanel.Controls.Clear();
                }));
            }
            else
            {
                queuePanel.Controls.Clear();
            }

            int x = padding;

            foreach (var element in queue)
            {
                var elementPanel = new Panel();
                elementPanel.Size = new Size(elementSize, elementSize);
                elementPanel.Location = new Point(x, padding);
                elementPanel.BackColor = element.Color;

                queuePanel.Invoke((MethodInvoker)delegate {
                    queuePanel.Controls.Add(elementPanel);
                });
                //queuePanel.Controls.Add(elementPanel);
                x += elementSize + padding;
            }
        }

        public void Enqueue(int R, int G, int B)
        {
            queue.Enqueue(new Square(R, G, B));
            UpdateQueueVisualizer();
        }

        public void Dequeue()
        {
            if (queue.Count > 0)
            {
                queue.Dequeue();
                UpdateQueueVisualizer();
            }
        }
    }
}
