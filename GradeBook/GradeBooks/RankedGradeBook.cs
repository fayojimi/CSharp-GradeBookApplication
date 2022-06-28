using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name): base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires a minimum of 5 students to work");
            }
            double count = Students.Where(e => e.AverageGrade > averageGrade).Count()+1.0;
            double percentage = count / (Students.Count+1.0);
            if (percentage <= 0.2)
            {
                return 'A';
            }
            else if (percentage <= 0.4)
            {
                return 'B';
            }
            else if (percentage <= 0.6)
            {
                return 'C';
            }
            else if (percentage <= 0.8)
            {
                return 'D';
            }
            return 'F';
            
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
