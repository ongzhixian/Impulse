﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WkspWinForms.WinFormsApp.DatabaseAccess;

namespace WkspWinForms.WinFormsApp.Domain
{
    [Table("teacher")]
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        public ICollection<Course> OnlineCourses { get; set; }
    }
}
