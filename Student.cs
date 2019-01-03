using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
  class Student : Person, IClonable
  {
    public enum Education
    {
      Master,
      Bachelor,
      SecondEducation,
      PhD
    }
    public Education educationLevel { get; set; }
    public string group { get; set; }
    public Examination[] exams { get; set; }
    private int number;
    public int record_book
    {
      get
      {
        return number;
      }

      set
      {
        if (value < 99999 || value > 99999999)
        {
          throw new Exception("Uncorrect number of record book!");
        }
        else
        {
          number = value;
        }
      }
    }

    public double avarage
    {
      get
      {
        double res = 0;
        for (int i = 0; i < exams.Length; ++i)
        {
          res += exams[i].points;
        }
        res /= exams.Length;
        return res;
      }
    }

    public Student()
    {
      exams = new Examination[0];
    }

    public void AddExams(Examination[] examList)
    {
      int examsLength;
      if (exams == null)
      {
        exams = new Examination[0];
        examsLength = 0;
      }
      else
      {
        examsLength = exams.Length;
      }
      int newLength = examsLength + examList.Length;
      Examination[] newExams = new Examination[newLength];
      for (int i = 0; i < examsLength; ++i)
      {
        newExams[i] = exams[i];
      }
      for (int i = examsLength; i < newLength; ++i)
      {
        newExams[i] = examList[i - examsLength];
      }
      exams = newExams;
    }

    public override string ToString()
    {
      return name + " " + surname + " " + group;
    }

    public override void PrintFullInfo()
    {
      string res = "";
      res += "Name:  " + name + "\n";
      res += "Surname:  " + surname + "\n";
      res += "Birthday:  " + birth_date.ToShortDateString() + "\n";
      res += "Education level:  " + educationLevel.ToString() + "\n";
      res += "Group:  " + group + "\n";
      res += "Record book № " + record_book.ToString() + "\n";
      res += "Exams:  \n";
      if (exams == null) exams = new Examination[0];
      for (int i = 0; i < exams.Length; ++i)
      {
        res += (i + 1).ToString() + ".  " + exams[i].ToString() + "\n";
      }
      res += "Average points:  " + avarage.ToString() + "\n\n";
      Console.Write(res);
    }

    public object clone()
    {
      Student stud = new Student();
      stud.name = this.name;
      stud.surname = this.surname;
      stud.birth_date = this.birth_date;
      stud.educationLevel = this.educationLevel;
      stud.group = this.group;
      stud.record_book = this.record_book;
      stud.exams = (Examination[])this.exams.Clone();
      return stud;
    }

    public IEnumerable GetExams() {
      foreach (Examination i in this.exams){
        if (i.is_dif) yield return i;
      }
    }
  }
}
