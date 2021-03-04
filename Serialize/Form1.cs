using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Serialize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [Serializable]
        private class Person
        {

            public Person(string firstname,string lastName, DateTime birthday)
            {
                Firstname = firstname;
                LastName = lastName;
                Birthday = birthday;
            }

            public string Firstname { get; set; }
            public string LastName { get; set; }
            [NonSerialized] 
            private int _age;

            public int CalcAge (DateTime birthday)
            {
                // Save today date.
                var today = DateTime.Today;
                _age = today.Year - birthday.Year;
                if (Birthday > today.AddYears(-_age)) _age--;
                return _age;
            }

            public int Age
            {
                get => CalcAge(Birthday);
                set
                {
                    _age = value;
                    CalcAge(Birthday);
                }
            }

            public DateTime Birthday { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var person = new Person(textBoxFname.Text, textBoxLname.Text, dateTimePickerBornDate.Value);
            numericUpDownAge.Value = person.Age;

            var formatter = new BinaryFormatter();
            var fs = new FileStream("person.dat",FileMode.Create,FileAccess.Write);
            formatter.Serialize(fs,person);
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var formatter = new BinaryFormatter();
            var fs = new FileStream("person.dat",FileMode.Open,FileAccess.Read);
            var person = (Person) formatter.Deserialize(fs);
            fs.Close();

            textBoxFname.Text = person.Firstname;
            textBoxLname.Text = person.LastName;
            numericUpDownAge.Value = person.Age;
            dateTimePickerBornDate.Value = person.Birthday;
        }

        private void dateTimePicker1_DateChanged(object sender, EventArgs e)
        {
            var person = new Person(textBoxFname.Text, textBoxLname.Text, dateTimePickerBornDate.Value);
            numericUpDownAge.Value = person.Age;
        }

        private void numericUpDownAge_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
