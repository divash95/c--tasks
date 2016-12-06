using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotationCalc;
using NotationCalc.Notations;


namespace NotCalcInterface
{
    public partial class Form1 : Form
    {
        Calculator c = new Calculator(new Dec());
        Translator t = new Translator();
        Dictionary<string, Notation> n = new Dictionary<string, Notation>();
        public Form1()
        {
            InitializeComponent();
            n.Add("Двоичная", new Bin());
            n.Add("Троичная", new Ter());
            n.Add("Четверичная", new Quater());
            n.Add("Десятичная", new Dec());
            n.Add("Шестандцатеричная", new Hex());
            comboBox1.Items.Add("Двоичная");
            comboBox1.Items.Add("Троичная");
            comboBox1.Items.Add("Четверичная");
            comboBox1.Items.Add("Десятичная");
            comboBox1.Items.Add("Шестандцатеричная");
            comboBox1.SelectedIndex = 3;


            comboBox2.Items.Add("Двоичная");
            comboBox2.Items.Add("Троичная");
            comboBox2.Items.Add("Четверичная");
            comboBox2.Items.Add("Десятичная");
            comboBox2.Items.Add("Шестандцатеричная");
            comboBox2.SelectedIndex = 3;

            comboBox3.Items.Add("Двоичная");
            comboBox3.Items.Add("Троичная");
            comboBox3.Items.Add("Четверичная");
            comboBox3.Items.Add("Десятичная");
            comboBox3.Items.Add("Шестандцатеричная");
            comboBox3.SelectedIndex = 3;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Add(textBox1.Text);
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.Sub(textBox1.Text);
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = c.Calculate(textBox1.Text);
            textBox1.Text = s;
            textBox2.Text = c.ToDec(s);
            textBox1.Focus();
            Form1: AcceptButton = button4;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            c.Reset();
            textBox1.Focus();
            Form1: AcceptButton = button1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            c.Reset();
            c.SetNotation(n[comboBox1.Text]);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Text = t.AtoB(textBox3.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox3.Text = t.BtoA(textBox4.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            t.aNot = n[comboBox2.Text];
            textBox3.Text = "";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            t.bNot = n[comboBox3.Text];
            textBox4.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char sym = e.KeyChar;
            if (textBox1.Text == "0")
                e.Handled = true;
            if (sym == '0' && textBox1.Text == "-")
                e.Handled = true;
            if (!(c.GetNotation().alphabet.ContainsKey(sym)))
            {
                e.Handled = true;
            }
            if (sym == '\b')
                e.Handled = false;
            if ((sym == '-' && textBox1.Text.Length == 0))
            {
                e.Handled = false;
            }

            
            Form1: AcceptButton = button1;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char sym = e.KeyChar;
            if (textBox3.Text == "0")
                e.Handled = true;
            if (sym == '0' && textBox3.Text == "-")
                e.Handled = true;
            if (!(t.aNot.alphabet.ContainsKey(sym)))
            {
                e.Handled = true;
            }
            if (sym == '\b')
                e.Handled = false;
            if ((sym == '-' && textBox3.Text.Length == 0))
            {
                e.Handled = false;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char sym = e.KeyChar;
            if (textBox4.Text == "0")
                e.Handled = true;
            if (sym == '0' && textBox4.Text == "-")
                e.Handled = true;
            if (!(t.bNot.alphabet.ContainsKey(sym)))
            {
                e.Handled = true;
            }
            if (sym == '\b')
                e.Handled = false;
            if ((sym == '-' && textBox4.Text.Length == 0))
            {
                e.Handled = false;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            textBox1.SelectionStart = textBox1.Text.Length - 1;
            textBox1.SelectionLength = 0;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text != "")
                textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                e.Handled = true;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
                textBox3.SelectionStart = textBox3.Text.Length - 1;
            textBox3.SelectionLength = 0;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
                textBox4.SelectionStart = textBox4.Text.Length - 1;
            textBox4.SelectionLength = 0;
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text != "")
                textBox4.SelectionStart = textBox4.Text.Length;
            textBox4.SelectionLength = 0;
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text != "")
                textBox3.SelectionStart = textBox3.Text.Length;
            textBox3.SelectionLength = 0;
        }

        


    }
}
