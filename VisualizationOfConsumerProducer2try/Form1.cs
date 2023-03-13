using VisualizationOfConsumerProducer2try.VisualizationOfConsumeAndProduce;

namespace VisualizationOfConsumerProducer2try
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Consumer consumer = new Consumer(panel4);

            Producer p1 = new Producer(0, panel1);
            Producer p2 = new Producer(1, panel2);
            Producer p3 = new Producer(2, panel3);

            consumer.Start();

            p1.Start();
            p2.Start();
            p3.Start();
        }
    }
}