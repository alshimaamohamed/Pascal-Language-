using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.calitha.commons;
using com.calitha.goldparser;

namespace ParserCompiler
{
    public partial class Form1 : Form
    {
        MyParser pascal;
        int i = 0;
        int preI = 0;
        string LastString = "";
        int Length = 0;
        public Form1()
        {
            InitializeComponent();
            pascal = new MyParser("Pascal_Task1_Ver1.5-3.cgt", listBox1);
            
        }
        //=========================Here=======================
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.ForeColor = Color.Black;
          //  LastString = richTextBox1.Text;
           
            string[] numofRows = richTextBox1.Text.Split('\n');
            i = numofRows.Length;
           
            pascal.Parse(richTextBox1.Text);
            string [] prev = richTextBox2.Text.Split('\n');
            richTextBox2.Text = "";

            if (richTextBox2.Text != "")
            {
                preI = Convert.ToInt32(prev[prev.Length-2]);
            }
            for (int l = 0; l < i; l++)
            {
                if (preI != i-1)
                {
                    richTextBox2.Text += l.ToString() + '\n';
                }
           }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_MultilineChanged(object sender, EventArgs e)
        {
            
            
        }
        //=========================Here========================
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.ForeColor = Color.Red;
        
           if (pascal.Semantic_Errors.Count != 0)
           {
               MessageBox.Show("There Are Some Errors !!", "Semantic Errors");
               for (int i = 0; i < pascal.Semantic_Errors.Count; i++)
               {
                   listBox1.Items.Add(pascal.Semantic_Errors[i]);
               }
           }
               
        }
    }
}
