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
    public partial class DelVar : Form
    {
        public DelVar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = (Form1)this.Owner;
            f1.c.DelVar(textBox1.Text);
            if (((Owner.Controls["comboBox1"] as ComboBox).SelectedItem as string) == textBox1.Text)
                Owner.Controls["textBox3"].Text = "";
            (Owner.Controls["comboBox1"] as ComboBox).Items.Remove(textBox1.Text);
            textBox1.Text = "";
        }
    }
}
