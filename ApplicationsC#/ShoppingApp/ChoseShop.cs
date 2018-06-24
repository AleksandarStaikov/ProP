using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingApp
{
    public partial class ChoseShop : Form
    {
        public int Choice =1;
        public  delegate void myChoiceEventHandler();
        public  event myChoiceEventHandler button1c;
        public  event myChoiceEventHandler button2c;
        public  event myChoiceEventHandler button3c;
        public  event myChoiceEventHandler button4c;


        public ChoseShop()
        {
            InitializeComponent();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Choice = 1;
            button1c();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Choice = 2;
            button2c();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Choice = 3;
            button3c();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Choice = 4;
            button4c();
            this.Visible = false;
        }
    }
}
