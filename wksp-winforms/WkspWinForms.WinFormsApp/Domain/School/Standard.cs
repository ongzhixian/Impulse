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
    [Table("standard")]
    public class Standard
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string StandardName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
