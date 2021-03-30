using System;
using System.Collections.Generic;

namespace ValidationXAMLForm
{
    class Employee:Person
    {
        public static List<Employee> Existing = new List<Employee>();

        public string Education { get; set; }
        
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
                else { throw new ArgumentException("Employee's Pay must be a number!"); }
            }
        }

        public Employee(string aName, string aLastName, string aBirthDate, string aJob, string aWage):base(aName, aLastName, aBirthDate)
        {
            Job = aJob;
            Wage = aWage;
            Existing.Add(this);
        }
    }
}
