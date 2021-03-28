using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WkspWinForms.WinFormsApp.DatabaseAccess;

namespace WkspWinForms.WinFormsApp.Domain
{
    [Table("student")]
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        ////Foreign key for Standard
        //[ForeignKey("Standard")]
        //public int StandardId { get; set; }
        //public Standard Standard { get; set; }

    }
}
