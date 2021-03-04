using FileReader.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FileReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private readonly OpenFileDialog _ofd = new OpenFileDialog();

        private void button1_Click(object sender, EventArgs e)
        {
            
            _ofd.Filter = Resources.extensions;
            if(_ofd.ShowDialog() != DialogResult.OK)
                return;
            if (ActiveForm != null) ActiveForm.Text = _ofd.FileName;
            var fileLines = new List<string>();
            var reader = new StreamReader(_ofd.FileName);
            while (true)
            {
                var s = reader.ReadLine();
                if(s==null)
                    break;
                fileLines.Add(s);
            }
            reader.Close();
            textBox1.Lines = fileLines.ToArray();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //textBox1.Lines = ofd.FileNames;
            var sw = File.CreateText(_ofd.FileName);
            foreach (var s in textBox1.Lines)
            {
                sw.WriteLine(s);
            }
            sw.Close();
            if (ActiveForm != null)
            {
                ActiveForm.Text = _ofd.FileName + Resources.saved;
                System.Threading.Tasks.Task.Delay(1000).Wait();
                ActiveForm.Text = _ofd.FileName;
            }
        }

    }
}
