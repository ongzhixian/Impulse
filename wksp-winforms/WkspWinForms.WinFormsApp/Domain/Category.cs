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
    [Table("category")]
    public class Category
    {
        private readonly ObservableListSource<Product> _products = new ObservableListSource<Product>();

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public virtual ObservableListSource<Product> Products { get { return _products; } }
    }
}
