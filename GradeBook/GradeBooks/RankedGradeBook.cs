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
            int count = Students.Where(e => e.AverageGrade > averageGrade).Count()+1;
            double percentage = count / Students.Count;
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
    }
}
