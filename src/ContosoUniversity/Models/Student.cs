﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string LastName { get; set; }

        [Required]
        [Display(Name ="First Name")]
        [StringLength(50,ErrorMessage ="First name cannot be longer than 50 characters")]
        public string FirstMidName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name ="Full Name")]
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
