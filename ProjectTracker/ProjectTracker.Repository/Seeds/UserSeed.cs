using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectTracker.Repository.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User { Id = 1, Name = "Ali",      Surname = "Yılmaz", Mail = "ali@example.com",          RoleId = 1 },
                new User { Id = 2, Name = "Ahmet",    Surname = "Yılmaz", Mail = "ahmet.yilmaz@example.com", RoleId = 1 },
                new User { Id = 3, Name = "Ayşe",     Surname = "Demir",  Mail = "ayse@example.com",         RoleId = 2 },
                new User { Id = 4, Name = "Ayşe",     Surname = "Kara",   Mail = "ayse.kara@example.com",    RoleId = 2 },
                new User { Id = 5, Name = "Muhammet", Surname = "Deneme", Mail = "muhammet@example.com",     RoleId = 2 },
                new User { Id = 6, Name = "Efe",      Surname = "Can",    Mail = "efe@example.com",          RoleId = 3 },
                new User { Id = 7, Name = "Mehmet",   Surname = "Demir",  Mail = "mehmet.demir@example.com", RoleId = 3 },
                new User { Id = 8, Name = "Elif",     Surname = "Çelik",  Mail = "elif.celik@example.com",   RoleId = 4 }
            );
        }
    }
}
