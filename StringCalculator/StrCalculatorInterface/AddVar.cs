using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrCalculatorInterface
{
    public partial class AddVar : Form
    {
        public AddVar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = (Form1)this.Owner;
            try
            {
                f1.c.AddVar(textBox1.Text, textBox2.Text);
                (Owner.Controls["comboBox1"] as ComboBox).Items.Add(textBox1.Text);
                
            }
            catch (FormatException)
            {

            }
            finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

    }
}
