﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Model
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Name { get; set; } 

        public string? Description { get; set; } 

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }
        public ICollection<StudentCourse> CourseEnrollments { get; set; } = new List<StudentCourse>();
        public ICollection<Resource> Resources { get; set; } = new List<Resource>();
        public ICollection<Homework> HomeworkSubmissions { get; set; } = new List<Homework>();
    }
}

