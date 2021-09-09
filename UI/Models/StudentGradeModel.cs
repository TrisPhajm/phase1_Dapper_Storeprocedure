using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class StudentGradeModel
    {
        public Student student {get;set;}
        public IEnumerable<StudentGrade> student_grade_list { get; set; }
        public bool Empty
        {
            get
            {
                return student_grade_list == null || student_grade_list.ToList().Count == 0;
            }
        }
    }
}
