using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task与Await关系验证
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox1.Text = "Doing Stuff";

            await Task.Delay(4000);
            await Task.Delay(3000);
            //await Task.Delay(3000);

            textBox1.Text = "Not Doing Anything";
            button1.Enabled = !button1.Enabled;

            //await test();
        }


        //private async Task<int> test()
        //{
        //    Thread.Sleep(10000);
        //    return 1;
        //}
    }
}
