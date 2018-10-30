using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfConsoleApp
{
    class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
