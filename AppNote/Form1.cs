using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace AppNote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Chức năng
        void Bold(RichTextBox rtxb)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name, rtxb.SelectionFont.Size, FontStyle.Bold);
            rtxb.SelectionFont = newFont;
        }
        void Italic(RichTextBox rtxb)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name, rtxb.SelectionFont.Size, FontStyle.Italic);
            rtxb.SelectionFont = newFont;
        }
        void Under(RichTextBox rtxb)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name, rtxb.SelectionFont.Size, FontStyle.Underline);
            rtxb.SelectionFont = newFont;
        }
        void ChangeSize(RichTextBox rtxb, int size)
        {
            Font newFont = new Font(rtxb.SelectionFont.FontFamily.Name, size, rtxb.SelectionFont.Style);
            rtxb.SelectionFont = newFont;
        }
        void ChangeFont(RichTextBox rtxb, string name)
        {
            Font newFont = new Font(name, rtxb.SelectionFont.Size, rtxb.SelectionFont.Style);
            rtxb.SelectionFont = newFont;
        }



        //Gọi chức năng
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bold(rtxb);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italic(rtxb);
        }

        private void underLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Under(rtxb);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeSize(rtxb, (int)comboBox2.SelectedIndex);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont(rtxb, comboBox1.Text);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                label1.Text = open.FileName;
                StreamReader read = new StreamReader(open.FileName);
                rtxb.Text = read.ReadToEnd();
                read.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter write = new StreamWriter(label1.Text.Trim());
            write.WriteLine(rtxb.Text);
            write.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "|*.txt";
            save.RestoreDirectory = true;
            if(save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(label1.Text.Trim());
                write.WriteLine(rtxb.Text);
                write.Close();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxb.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxb.Cut();
        }

        private void pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxb.Paste();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter("NewFile.txt");
            file.Close();
        }
    }
}
