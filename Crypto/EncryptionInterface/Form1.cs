using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Encryption;
using Encryption.Workers;

namespace EncryptionInterface
{
    public partial class Form1 : Form
    {
        string path = Environment.CurrentDirectory + "\\res.txt";
        Crypto c = new Crypto();
        private Error err = new Error();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            AddOwnedForm(err);
            string st = Environment.CurrentDirectory;
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter = "All files (*.txt*)|*.txt*";
            openFileDialog1.RestoreDirectory = true;
            comboBox1.Items.Add("Цезарь");
            comboBox1.Items.Add("Виженер");
            comboBox1.SelectedIndex = 0;
            textBox3.Text = "3";
            Cesar ces = new Cesar(3);
            textBox4.Text = "5";
            c.ChangePool(5, ces);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    Cesar ces = new Cesar(Convert.ToInt32(textBox3.Text));
                    c.ChangePool(Convert.ToInt32(textBox4.Text), ces);
                }
                else
                {
                    Vig v = new Vig(textBox3.Text, c.chArr);
                    c.ChangePool(Convert.ToInt32(textBox4.Text), v);
                }
            }
            catch(ArgumentException ex)
            {
                err.ShowDialog();
                textBox3.Text = c.GetKey();
                textBox4.Text = c.GetWorkCount().ToString();
            }
            catch(SystemException ex)
            {
                err.ShowDialog();
                textBox3.Text = c.GetKey();
                textBox4.Text = c.GetWorkCount().ToString() ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = c.Encrypt(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = c.Decode(textBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); 
            if (result == DialogResult.OK) 
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file, System.Text.Encoding.GetEncoding(1251));
                    File.WriteAllText(path, c.Encrypt(text));
                }
                catch (IOException)
                {
                }
                catch(UnauthorizedAccessException)
                {
                    err.ShowDialog();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file, System.Text.Encoding.GetEncoding(1251));
                    File.WriteAllText(path, c.Decode(text));
                }
                catch (IOException)
                {
                }
                catch (UnauthorizedAccessException)
                {
                    err.ShowDialog();
                }
            }
        }


    }
}
