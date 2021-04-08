using System;

namespace ValidationXAMLForm
{
    public class Person
    {
        public string Name { get; set; }
        string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (value.Length > 1) { _LastName = value; }
                else { throw new ArgumentException("Person's last name must have at least two letters!"); }
            }
        }
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
            _Name = "";
            _LastName = "";
            _BirthYear = "";
        }
    }
}
