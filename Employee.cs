using System;
using System.Collections.Generic;

namespace ValidationXAMLForm
{
    public class Employee:Person
    {
        public static List<Employee> Existing = new List<Employee>();

        public int EducationIndex { get; set; }
        public string Education //this could be probably done easyer with enum
        {
            get 
            {
                switch (EducationIndex)
                {
                    case 0:
                        return "Základní vzdělání";
                    case 1:
                        return "Výuční list";
                    case 2:
                        return "Maturitní zkouška";
                    case 3:
                        return "Vyšší vzdělání";
                    default:
                        return "Invalid education index!";
                }
            }
            set
            {
                switch (value)
                {
                    case "Základní vzdělání":
                        EducationIndex = 0;
                        break;
                    case "Výuční list":
                        EducationIndex = 1;
                        break;
                    case "Maturitní zkouška":
                        EducationIndex = 2;
                        break;
                    case "Vyšší vzdělání":
                        EducationIndex = 3;
                        break;
                    default:
                        throw new ArgumentException("Invalid Education string entered");
                }
            }
        }

        public string Job { get; set; }

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
            Job = "";
            _Wage = "";
            EducationIndex = 4;
            Existing.Add(this);
        }
    }
}
