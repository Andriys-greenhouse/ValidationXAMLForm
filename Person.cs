using System;

namespace ValidationXAMLForm
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthYear { get; set; }

        public Person(string aName, string aLastName, string aBirthDate)
        {
            Name = aName;
            LastName = aLastName;
            BirthYear = aBirthDate;
        }

        public Person()
        {
            Name = "";
            LastName = "";
            BirthYear = "";
        }
    }
}
