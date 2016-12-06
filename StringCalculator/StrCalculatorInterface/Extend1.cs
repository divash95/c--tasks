using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using StrCalculator;
using StrCalculator.Formuls;

namespace StrCalculatorInterface
{
    public partial class Extend1 : Form
    {
        public Extend1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Константа");
            comboBox1.Items.Add("Переменная");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = (Form1)this.Owner;
            if (comboBox1.SelectedIndex == 0)
            {
                f1.c.Extend(new Constant(this.textBox1.Text));
                Owner.Controls["textBox1"].Text = f1.c.GetStr(); 
            }
            else
            {
                f1.c.Extend(new Variable(this.textBox1.Text, f1.c.vars));
                Owner.Controls["textBox1"].Text = f1.c.GetStr(); 
            }
            textBox1.Text = "";
        }
    }
}
