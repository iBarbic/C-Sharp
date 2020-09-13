using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vjezba6
{
    public partial class AddPersonForm : Form
    {
        private Person person = new Person();
        public AddPersonForm()
        {
            InitializeComponent();
        }
        public AddPersonForm(Person person)
        {
            InitializeComponent();
            this.person = person;
            textBoxName.Text = this.person.name;
            textBoxLastName.Text = this.person.lastName ;
            textBoxAge.Text = this.person.age.ToString();
            comboBoxCity.Text = this.person.city;
        }
       
        public Person getNewPerson()
        {                        
            return person;
        }
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            this.person.name = textBoxName.Text;
            this.person.lastName = textBoxLastName.Text;
            this.person.age = Int32.Parse(textBoxAge.Text);
            this.person.city = comboBoxCity.Text;
        }
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (dataIsValid())
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }

        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            if (dataIsValid())
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }

        }

        private void textBoxAge_TextChanged(object sender, EventArgs e)
        {
            if (dataIsValid())
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }

        }

        private void comboBoxCity_TextChanged(object sender, EventArgs e)
        {
            if (dataIsValid())
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }

        }
        private bool dataIsValid()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxAge.Text) || !int.TryParse(textBoxAge.Text, out int dump))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(comboBoxCity.Text))
            {
                return false;
            }
            return true;
        }

        private void newPersonForm_Load(object sender, EventArgs e)
        {

        }
    }
}
