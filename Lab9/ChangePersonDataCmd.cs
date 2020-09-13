using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs
{
    class ChangePersonDataCmd:AbstractCommand
    {
        private Person personBefore, personAfter;

        public ChangePersonDataCmd(Person personInChange)
        {
            personBefore = personInChange.shallowCopy();
            personAfter = personInChange;
        }
        public override void doit()
        {
            Person tempPerson = personAfter.shallowCopy();
            

            personAfter.Name = personBefore.Name;
            personAfter.LastName = personBefore.Name;
            personAfter.Age = personBefore.Age;
            personAfter.City = personBefore.City;

            personAfter.updateTreeText();

            personBefore = tempPerson; 
            
        }

        public override void redo()
        {
            doit();
        }

        public override void undo()
        {
            doit();
        }
    }
}
