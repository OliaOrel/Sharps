using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
  class Examination : IClonable
  {
    public int semester { get; set; }
    public string subject { get; set; }
    public string teacher { get; set; }
    public int points { get; set; }
    public bool is_dif { get; set; }
    public DateTime date { get; set; }

    public Examination() {
      this.semester = 2;
      this.subject = "OOP";
      this.teacher = "Mukha I.P.";
      this.points = 100;
      this.is_dif = true;
      this.date = new DateTime(2018, 6, 14);
    }

    public Examination(int semester, string subject, string teacher, int points, bool is_dif, DateTime date) {
      this.semester = semester;
      this.subject = subject;
      this.teacher = teacher;
      this.points = points;
      this.is_dif = is_dif;
      this.date = Convert.ToDateTime(date);
    }

    public override string ToString() {
      string result = "\nSubject: " + this.subject + '\n'
      + "Teacher: " + this.teacher.Split(' ')[0] + '\n'
      + "Points: " + this.points.ToString() + '\n';
      return result.ToString();
    }

    public object clone()
    {
      return new Examination()
      {
        semester = this.semester,
        subject = this.subject,
        teacher = this.teacher,
        points = this.points,
        is_dif = this.is_dif,
        date = this.date
      };
    }
  }
}
