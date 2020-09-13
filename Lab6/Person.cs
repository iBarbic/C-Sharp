using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjezba_6
{
    public class Person
    {
        public String name { get; set; }
        public String lastName { get; set; }
        public String city { get; set; }
        public int age { get; set; }

        public Person()
        {

        }
        public Person(string name, string lastName, string city, int age)
        {
            this.name = name;
            this.lastName = lastName;
            this.city = city;
            this.age = age;
        }
    }
}
