using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
  public interface IClonable
  {
    object clone();
  }
  class Program
  {
    static void Main(string[] args)
    {
      Console.Write("\t=== A. ===\n");

      Student student1 = new Student();
      student1.name = "Olha";
      student1.surname = "Orel";
      student1.group = "IP-71";
      try
      {
        student1.record_book = 997123;
      }
      catch (Exception ex)
      {
        Console.WriteLine("ERROR: " + ex.Message);
      }
      student1.birth_date = new DateTime(2000, 11, 20);
      student1.birth_year = 1999;
      student1.educationLevel = Student.Education.Bachelor;
      Console.Write(student1.ToString() + "\n");
      Console.Write("\n");

      Console.Write("\t=== B. ===\n");

      Examination[] exams = new Examination[3]{
        new Examination(),
        new Examination(1, "KDM", "Likhouzova T.M.", 99, true, new DateTime(2018, 1, 11)),
        new Examination(3, "Phylosofy", "Kutsyk K.M.", 95, false, new DateTime(2017, 12, 23))
      };

      student1.AddExams(exams);
      Console.Write(student1.ToString() + "\n");
      Console.Write("\n");

      Console.Write("\t=== C. ===\n");

      student1.PrintFullInfo();
      Console.Write("\n");

      Console.Write("\t=== D. ===\n");

      Console.Write("\t=== Task 1. ===\n");
      Student student2 = (Student)student1.clone();
      Console.Write("New student with the same information:\n");
      student2.PrintFullInfo();
      try
      {
        student2.record_book = 997125;
      }
      catch (Exception ex)
      {
        Console.WriteLine("ERROR: " + ex.Message);
      }
      student2.surname = "Doms";
      Console.Write("Student1 after changing student2:\n");
      student1.PrintFullInfo();
      Console.Write("Student2 (changed surname and record book):\n");
      student2.PrintFullInfo();

      Console.Write("\t=== Task 4. ===\n");
      try
      {
        student2.record_book = 999997125;
      }
      catch (Exception ex)
      {
        Console.WriteLine("ERROR: " + ex.Message);
      }
      Console.Write("\n");

      Console.Write("\t=== Task 8. ===\n");
      Console.Write("Only exams:\n");
      foreach (Examination exam in student1.GetExams())
      {
          Console.Write(exam.ToString());
      }
      Console.Write("\n");

      Console.Write("\t=== Task 11. ===\n");
      Console.Write("Birthday student1: " + student1.birth_date.ToShortDateString() + "\nAge 1: " + student1.getAge().ToString() + "\n");
      student2.birth_date = new DateTime(2000, 8, 21);
      Console.Write("Birthday student2: " + student2.birth_date.ToShortDateString() + "\nAge 2: " + student2.getAge().ToString() + "\n");
    }
  }
}
