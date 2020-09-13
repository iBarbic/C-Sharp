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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void newPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonForm personForm = new PersonForm();
            personForm.ShowDialog(this);

            if(personForm.DialogResult == DialogResult.OK)
            {
                Person person = personForm.getPerson();

                String[] row = { person.name, person.lastName };
                ListViewItem item = new ListViewItem(row);
                item.Tag = person; 

                listView1.Items.Add(item);

            }
        }

        private void viewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person person = (Person) listView1.SelectedItems[0].Tag;
            PersonForm personForm = new PersonForm(person);
            personForm.ShowDialog(this);

            if(personForm.DialogResult == DialogResult.OK)
            {
                person = personForm.getPerson();
                listView1.Items.Remove(listView1.SelectedItems[0]);

                String[] row = { person.name, person.lastName };
                ListViewItem item = new ListViewItem(row);
                item.Tag = person;

                listView1.Items.Add(item);
            }

        }
    }
}
