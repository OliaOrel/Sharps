using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
  class Person
  {
    public string name {get; set;}
    public string surname {get; set;}
    public DateTime birth_date;

    public int birth_year {
      get { return this.birth_date.Year; }

      set {
        int year = value;
        int month = this.birth_date.Month;
        int day = this.birth_date.Day;

        this.birth_date = new DateTime(year, month, day);
      }
    }

    public Person() {
      this.name = "Ivan";
      this.surname = "Ivanov";
      this.birth_date = new DateTime(2000, 1, 1);
    }

    public Person(string name, string surname, DateTime birth_date) {
      this.name = name;
      this.surname = surname;
      this.birth_date = birth_date;
    }

    public virtual void PrintFullInfo() {
      Console.WriteLine("Name: " + this.name);
      Console.WriteLine("Surname: " + this.surname);
      Console.WriteLine("Date of birth: " + this.birth_date.ToShortDateString());
    }

    public int getAge()
    {
      DateTime now = DateTime.Now;
      TimeSpan age = now - birth_date;
      return age.Days / 365;
    }
  }
}
