using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Models;
using WebStore.Models.Enumerations;

namespace WebStore.Repositories
{
    public class Context : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public DbSet<UserRoleModel> UserRoles { get; set; }

        public DbSet<PropertyTextValueModel> PropertyTextValues { get; set; }

        public DbSet<PropertyIntegerValueModel> PropertyIntegerValues { get; set; }

        public DbSet<PropertyDecimalValueModel> PropertyDecimalValues { get; set; }

        public DbSet<PropertyUnitModel> PropertyUnits { get; set; }
        
        public DbSet<PropertyModel> Property { get; set; }
        
        public DbSet<PropertyGroupModel> PropertyGroups { get; set; }
        
        public DbSet<ProductModel> Product { get; set; }

        public DbSet<ProductTypeModel> ProductTypes { get; set; }

        public DbSet<ProducerModel> Producers { get; set; }

        public DbSet<OrderingModel> Orderings { get; set; }
        
        public DbSet<OrderingItemModel> OrderingItems { get; set; }

        public DbSet<OrderingInformationModel> OrderingInformaions { get; set; }
        
        public DbSet<ImageModel> Images { get; set; }

        public DbSet<ComponentModel> Components { get; set; }

        public DbSet<AnonimousUserModel> AnonimousUsers { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        private void ClearDb()
        {
            Database.EnsureDeleted();
        }

        public static void Clear()
        {
            new Context().ClearDb();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CoolLifeDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserModel>()
            //    .HasMany(u => u.Roles)
            //    .WithMany(r => r.Users)
            //    .UsingEntity(j => j.ToTable("UsersAndroles"));

            //var UserRoles = Enum.GetValues<UserRolesEnumeration>().Select(e => new UserRoleModel() { Id = e }).ToList();
            //var users = new UserModel[]
            //{
            //    new UserModel
            //    {
            //        Id = Guid.NewGuid(),
            //        Login = "email@example.com",
            //        Password = "12345",
            //        Roles = UserRoles,
            //    },
            //};
            //UserRoles.ForEach(r => r.Users.AddRange(users));
            //modelBuilder.Entity<UserRoleModel>().HasData(UserRoles);

            //modelBuilder.Entity<UserModel>().HasData(users);

            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.ProductType)
                .WithMany(t => t.Products)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PropertyModel>()
                .HasOne(p => p.Group)
                .WithMany(g => g.Properties)
                .OnDelete(DeleteBehavior.Restrict);

            var users = new UserModel[]
            {
                 new UserModel
                {
                    Id = Guid.NewGuid(),
                    Login = "email@example.com",
                    Password = "12345",
                }
            };

            modelBuilder.Entity<UserModel>().HasData(users);

            var userRoles = Enum.GetValues<UserRolesEnumeration>().Select(e => new UserRoleModel() { Id = e }).ToList();
            //userRoles.ForEach(r => r.Users = users.ToList());

            modelBuilder.Entity<UserRoleModel>().HasData(userRoles);

            var groups = new PropertyGroupModel[]
            {
                new PropertyGroupModel //base property
                {
                    Id = (int)BasePropertyGroupIdEnumeration.ProductType,
                    Name = "Тип устройства",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Text,
                },
                new PropertyGroupModel //base property
                {
                    Id = (int)BasePropertyGroupIdEnumeration.Producer,
                    Name = "Производитель",
                    TypeId = (int)Models.Enumerations.PropertyTypeEnumeration.Text,
                },
            };
            modelBuilder.Entity<PropertyGroupModel>().HasData(groups);
        }
    }
}
