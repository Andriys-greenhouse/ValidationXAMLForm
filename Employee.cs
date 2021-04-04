using System;
using System.Collections.Generic;

namespace ValidationXAMLForm
{
    public class Employee:Person
    {
        public static List<Employee> Existing = new List<Employee>();

        string _Education;
        public string Education
        {
            get { return _Education; }
            set
            {
                if (value.Length > 1) { _Education = value; }
                else { throw new ArgumentException("Employee's education must have at least two letters!"); }
            }
        }

        string _Job;
        public string Job
        {
            get { return _Job; }
            set
            {
                if (value.Length > 1) { _Job = value; }
                else { throw new ArgumentException("Employee's job must have at least two letters!"); }
            }
        }

        string _Wage;
        public string Wage
        {
            get { return _Wage; }
            set
            {
                if (int.TryParse(value, out int notNeeded)) { _Wage = value; }
                else { throw new ArgumentException("Employee's pay must be a number!"); }
            }
        }

        public Employee(string aName, string aLastName, string aBirthDate, string aEducation, string aJob, string aWage):base(aName, aLastName, aBirthDate)
        {
            Job = aJob;
            Wage = aWage;
            Education = aEducation;
            Existing.Add(this);
        }

        public Employee() : base()
        {
            _Job = "";
            _Wage = "";
            _Education = "";
            Existing.Add(this);
        }
    }
}
