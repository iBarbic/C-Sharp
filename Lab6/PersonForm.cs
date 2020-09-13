using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vjezba_6
{
    public partial class PersonForm : Form
    {

        private Person person = new Person();
        public PersonForm()
        {
            InitializeComponent();
        }

        public PersonForm(Person person)
        {
            InitializeComponent();
            this.person = person;
            textBox1.Text = person.name;
            textBox2.Text = person.lastName;
            textBox3.Text = person.age.ToString();
            comboBox1.Text = person.city;
        }

        public Person getPerson()
        {
            return person;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            person.name = textBox1.Text;
            person.lastName = textBox2.Text;
            person.age = Int32.Parse(textBox3.Text);
            person.city = comboBox1.Text;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(validate())
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

        }

        private bool validate()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text) || !int.TryParse(textBox3.Text, out int dump))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
