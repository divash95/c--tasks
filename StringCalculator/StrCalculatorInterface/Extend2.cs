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
    public partial class Extend2 : Form
    {
        public Extend2()
        {
            InitializeComponent();
            comboBox1.Items.Add("Удалить подстроку");
            comboBox1.Items.Add("Слияние со строкой");
            comboBox1.Items.Add("Заменить подстроку на подстроку");
            comboBox1.Items.Add("Удалить начальные и конечные пробелы");
            comboBox1.Items.Add("Заменить пробелы на символ");
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add("Константа");
            comboBox2.Items.Add("Переменная");
            comboBox2.SelectedIndex = 0;
            comboBox3.Items.Add("Константа");
            comboBox3.Items.Add("Переменная");
            comboBox3.SelectedIndex = 0;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(this.comboBox1.SelectedIndex)
            {
                case 3:
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    break;
                case 0: case 1: case 4:
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    break;
                default:
                    groupBox1.Visible = true;
                    groupBox2.Visible = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = (Form1)this.Owner;
            switch (this.comboBox1.SelectedIndex)
            {
                case 0:
                    if (comboBox2.SelectedIndex == 0)
                        f1.c.Extend(new SubStrRemove(f1.c.formul, new Constant(textBox1.Text)));
                    else
                        f1.c.Extend(new SubStrRemove(f1.c.formul, new Variable(textBox1.Text, f1.c.vars)));
                    Owner.Controls["textBox1"].Text = f1.c.GetStr();
                    break;

                case 1:
                    if (comboBox2.SelectedIndex == 0)
                    
                        f1.c.Extend(new StringConc(f1.c.formul, new Constant(textBox1.Text)));
                    
                    else
                        f1.c.Extend(new StringConc(f1.c.formul, new Variable(textBox1.Text, f1.c.vars)));
                    Owner.Controls["textBox1"].Text = f1.c.GetStr();
                    break;

                case 2: 
                    if (comboBox2.SelectedIndex == 0)
                        if (comboBox3.SelectedIndex == 0)
                            f1.c.Extend(new SubStrReplace(f1.c.formul, new Constant(textBox1.Text), new Constant(textBox2.Text)));
                        else
                            f1.c.Extend(new SubStrReplace(f1.c.formul, new Constant(textBox1.Text), new Variable(textBox2.Text, f1.c.vars)));
                    else
                        if (comboBox3.SelectedIndex == 0)
                            f1.c.Extend(new SubStrReplace(f1.c.formul, new Variable(textBox1.Text, f1.c.vars), new Constant(textBox2.Text)));
                        else
                            f1.c.Extend(new SubStrReplace(f1.c.formul, new Variable(textBox1.Text, f1.c.vars), new Variable(textBox2.Text, f1.c.vars)));
                    Owner.Controls["textBox1"].Text = f1.c.GetStr();
                    break;
                case 3:
                    f1.c.Extend(new SpaceRemove(f1.c.formul));
                    Owner.Controls["textBox1"].Text = f1.c.GetStr();
                    break;
                case 4:
                    if (comboBox2.SelectedIndex == 0)
                        f1.c.Extend(new SpaceReplace(f1.c.formul, new Constant(textBox1.Text)));                  
                    else
                        f1.c.Extend(new SpaceReplace(f1.c.formul, new Variable(textBox1.Text, f1.c.vars)));
                    Owner.Controls["textBox1"].Text = f1.c.GetStr();
                    break;
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
