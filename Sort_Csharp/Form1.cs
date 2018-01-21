using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

using Sort_Csharp;

namespace Sort_Csharp_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static int iElements = 0;
        public static int iMax = 0;

        Thread sortThread;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                iElements = Convert.ToInt32(textBox1.Text);
                iMax = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                return;
            }

            sortThread = new Thread(SortThread);
            sortThread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sortThread.Abort();
        }

        private void SortThread()
        {
            int[] List = new int[iElements];
            CreateRandomIntArray(ref List, iMax);

            Console.Beep();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Sort.ArrayMergeSort(ref List);

            stopwatch.Stop();
            Console.Beep();
            this.Invoke((MethodInvoker)delegate
            {
                label2.Text = "Zeit: " + stopwatch.ElapsedMilliseconds + "ms";
            });
        }

        public static void CreateRandomIntArray(ref int[] List, int iMax)
        {
            Random random = new Random();

            for (int i = 0; i < List.Length; i++)
            {
                List[i] = random.Next(iMax);
            }
        }
    }
}
