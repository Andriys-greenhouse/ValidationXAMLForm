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
                        return "Žádné vzdělání";
                    case 1:
                        return "Základní vzdělání";
                    case 2:
                        return "Výuční list";
                    case 3:
                        return "Maturitní zkouška";
                    case 4:
                        return "Vyšší vzdělání";
                    default:
                        return "Invalid education index!";
                }
            }
            set
            {
                switch (value)
                {
                    case "Žádné vzdělání":
                        EducationIndex = 0;
                        break;
                    case "Základní vzdělání":
                        EducationIndex = 1;
                        break;
                    case "Výuční list":
                        EducationIndex = 2;
                        break;
                    case "Maturitní zkouška":
                        EducationIndex = 3;
                        break;
                    case "Vyšší vzdělání":
                        EducationIndex = 4;
                        break;
                    default:
                        throw new ArgumentException("Invalid Education string entered");
                }
            }
        }

        public string Job { get; set; }

        public string Wage { get; set; }

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
            Wage = "";
            EducationIndex = 0;
            Existing.Add(this);
        }
    }
}
