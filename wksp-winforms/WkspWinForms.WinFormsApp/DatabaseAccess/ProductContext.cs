using System.Data.Entity;
using WkspWinForms.WinFormsApp.Domain;

namespace WkspWinForms.WinFormsApp.DatabaseAccess
{
    public class ProductContext : DbContext
    {
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Product> Products { get; set; }

        public ProductContext() : base("WinFormsAppDatabase")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MyContext>(modelBuilder);
            //Database.SetInitializer(sqliteConnectionInitializer);
            //Database.SetInitializer()
            //var x = new CreateDatabaseIfNotExists<ProductContext>()

            //Database.SetInitializer(x)

            base.OnModelCreating(modelBuilder);
        }
    }
}
