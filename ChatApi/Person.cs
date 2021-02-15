using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi
{
    public class Person
    {
        public Person(string _id, string _name)
        {
            PersonID = _id;
            PersonName = _name;
        }

        private string personID;

        public string PersonID
        {
            get { return personID; }
            set { personID = value; }
        }

        private string personName;

        public string PersonName
        {
            get { return personName; }
            set { personName = value; }
        }
    }
}
