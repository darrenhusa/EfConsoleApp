using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfConsoleApp
{
    class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Dept { get; set; }
        public int CourseNumber { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }

    }
}
