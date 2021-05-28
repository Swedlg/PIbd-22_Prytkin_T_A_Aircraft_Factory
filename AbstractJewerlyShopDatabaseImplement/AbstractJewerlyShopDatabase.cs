using AbstractJewerlyShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace AbstractJewerlyShopDatabaseImplement
{
    public class AbstractJewerlyShopDatabase : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AbstractJewerlyShopDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Component> Components { set; get; }

        public virtual DbSet<Jewel> Jewels { set; get; }

        public virtual DbSet<JewelComponent> JewelComponents { set; get; }

        public virtual DbSet<Order> Orders { set; get; }

        public virtual DbSet<Client> Clients { set; get; }
    }
}
