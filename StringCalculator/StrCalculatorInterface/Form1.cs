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
    public partial class Form1 : Form
    {
        public Calculator c = new Calculator();
        private Extend1 extend1 = new Extend1();
        private Extend2 extend2 = new Extend2();
        private AddVar addvar = new AddVar();
        private DelVar delvar = new DelVar();
        public Form1()
        {
            InitializeComponent();
            AddOwnedForm(extend1);
            AddOwnedForm(extend2);
            AddOwnedForm(addvar);
            AddOwnedForm(delvar);
            Calculator c = new Calculator();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                extend1.ShowDialog();
            else
                extend2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Reset();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            c.Prev();
            textBox2.Text = "";
            textBox1.Text = c.GetStr();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = c.Calculate();
            }
            catch (NullReferenceException ex)
            {
                Error error = new Error(ex.Message);
                error.ShowDialog();
            }
            catch(ArgumentException ex)
            {
                Error error = new Error(ex.Message);
                error.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addvar.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delvar.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string t = c.vars[comboBox1.SelectedItem as string];
            textBox3.Text = t;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string cstr = comboBox1.SelectedItem as string;
            if (cstr != null)
                c.ChangeVar(cstr, textBox3.Text);
        }
    }
}
