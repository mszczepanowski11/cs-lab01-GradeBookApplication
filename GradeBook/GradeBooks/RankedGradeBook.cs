using System;
using GradeBook.Enums;
namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

        double gradeCount = 0.0;
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].AverageGrade <= averageGrade)
                {
                    gradeCount++;
                }
            }

            if (gradeCount / Students.Count > 0.8) return 'A';
            else if( gradeCount / Students.Count > 0.6) return 'B';
            else if( gradeCount / Students.Count > 0.4) return 'C';
            else if( gradeCount / Students.Count > 0.2) return 'D';
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students");
            else 
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students");
            else
                 base.CalculateStudentStatistics(name);
        }
    }
}