using Microsoft.EntityFrameworkCore;
using MyPortolioHomeWork.DAL.Entities;

namespace MyPortolioHomeWork.DAL.Context
{
    public class MyPortfolioContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings__Portfolio")
                ?? "Server=(localdb)\\MSSQLLocalDB;initial Catalog=MyPortfolioDb;integrated Security=true;");
        }

        public DbSet<About> abouts { get; set; }
        public DbSet<Contact> contacts{ get; set; }

        public DbSet<Experience> experiences{ get; set; }
        public DbSet<Feature>  features { get; set; }
        public DbSet<Message>  messages { get; set; }
        public DbSet<Portfolio>  portfolios { get; set; }
        public DbSet<Skill>  skills { get; set; }
        public DbSet<SocialMedia>  socialMedias{ get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
