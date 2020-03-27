using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenD = new OpenFileDialog();
            if (OpenD.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenD.FileName, Encoding.Default);
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            OpenD.Dispose();

        }


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveD = new SaveFileDialog();
            if (SaveD.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(SaveD.FileName);
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    Writer.WriteLine((string)listBox2.Items[i]);
                }
                Writer.Close();
            }
            SaveD.Dispose();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Информация о приложении и разработчике");
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenD = new OpenFileDialog();
            if (OpenD.ShowDialog() == DialogResult.OK)
            {
                StreamReader Reader = new StreamReader(OpenD.FileName, Encoding.Default);
                richTextBox1.Text = Reader.ReadToEnd();
                Reader.Close();
            }
            OpenD.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            listBox1.BeginUpdate();

            string[] Strings = richTextBox1.Text.Split(new char[] { '\n', '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in Strings)
            {
                string Str = s.Trim();
                if (Str == String.Empty) continue;
                if (radioButton1.Checked) listBox1.Items.Add(Str);
                if(radioButton2.Checked)
                {
                    if (Regex.IsMatch(Str, @"\d")) listBox1.Items.Add(Str);
                }
                if (radioButton3.Checked)
                {
                    if (Regex.IsMatch(Str, @"\w+@\w+\.\w+")) listBox1.Items.Add(Str);
                }
            }
            listBox1.EndUpdate();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            richTextBox1.Clear();
            textBox1.Clear();
            radioButton1.Checked = true;
            checkBox1.Checked = true;
            checkBox2.Checked = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            string Find = textBox1.Text;
            if(checkBox1.Checked)
            {
                foreach(string String in listBox1.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
            if (checkBox2.Checked)
            {
                foreach (string String in listBox2.Items)
                {
                    if (String.Contains(Find)) listBox3.Items.Add(String);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 AddRec = new Form2();
            AddRec.Owner = this;
            AddRec.ShowDialog();
        }


        private void DeleteSelectedStrings(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (listBox1.GetSelected(i)) listBox1.Items.RemoveAt(i);
            }
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                if (listBox2.GetSelected(i)) listBox2.Items.RemoveAt(i);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.BeginUpdate();
            foreach(object Item in listBox1.SelectedItems)
            {
                listBox2.Items.Add(Item);
                
            }
            listBox2.EndUpdate();
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.BeginUpdate();
            foreach (object Item in listBox2.SelectedItems)
            {
                listBox1.Items.Add(Item);

            }
            listBox1.EndUpdate();
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Алфавиту (по возрастанию)")
            {
                List<String> list = new List<String>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                list.Sort();
                listBox1.Items.Clear();
                foreach (var item in list)
                    listBox1.Items.Add(item);
            }
            if (comboBox1.Text == "Алфавиту (по убыванию)")
            {
                List<String> list = new List<String>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                list.Sort();
                list.Reverse();
                listBox1.Items.Clear();
                foreach (var item in list)
                    listBox1.Items.Add(item);
            }
            if (comboBox1.Text == "Длине слова (по возрастанию)")
            {
                List<String> list = new List<String>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                listBox1.Items.Clear();
                var sortResult = list.OrderBy(x => x.Length);
                foreach (var item in sortResult)
                    listBox1.Items.Add(item);
            }
            if (comboBox1.Text == "Длине слова (по убыванию)")
            {
                List<String> list = new List<String>();
                foreach (var item in listBox1.Items)
                    list.Add(item.ToString());

                listBox1.Items.Clear();
                var sortResult = list.OrderByDescending(x => x.Length);
                foreach (var item in sortResult)
                    listBox1.Items.Add(item);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Алфавиту (по возрастанию)")
            {
                List<String> list = new List<String>();
                foreach (var item in listBox2.Items)
                    list.Add(item.ToString());

                list.Sort();
                listBox2.Items.Clear();
                foreach (var item in list)
                    listBox2.Items.Add(item);
            }
            if (comboBox2.Text == "Алфавиту (по убыванию)")
            {
                List<String> list = new List<String>();
                foreach (var item in listBox2.Items)
                    list.Add(item.ToString());

                list.Sort();
                list.Reverse();
                listBox2.Items.Clear();
                foreach (var item in list)
                    listBox2.Items.Add(item);
            }
            if (comboBox2.Text == "Длине слова (по возрастанию)")
            {
                List<String> list = new List<String>();
                foreach (var item in listBox2.Items)
                    list.Add(item.ToString());

                listBox2.Items.Clear();
                var sortResult = list.OrderBy(x => x.Length);
                foreach (var item in sortResult)
                    listBox2.Items.Add(item);
            }
            if (comboBox2.Text == "Длине слова (по убыванию)")
            {
                List<String> list = new List<String>();
                foreach (var item in listBox2.Items)
                    list.Add(item.ToString());

                listBox2.Items.Clear();
                var sortResult = list.OrderByDescending(x => x.Length);
                foreach (var item in sortResult)
                    listBox2.Items.Add(item);
            }
        }
    }
}
