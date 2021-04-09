using System;

namespace ValidationXAMLForm
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        string _BirthYear;
        public string BirthYear
        {
            get { return _BirthYear; }
            set
            {
                if (int.TryParse(value, out int notNeeded)) { _BirthYear = value; }
                else { throw new ArgumentException("Person's birth date must be a number!"); }
            }
        }

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
            _BirthYear = "";
        }
    }
}
