using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Data
{
    public class MyAppContext : DbContext
    {
        public DbSet<Player> Players { get; set; }


        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

            //Database.EnsureDeleted();
            Database.EnsureCreated();
            //AddSampleData();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




        }


        private void AddSampleData()
        {
            var spiller = new Player() { Name = "Danny" };
            Players.Add(spiller);

            var spiller2 = new Player() { Name = "Jens" };
            Players.Add(spiller2);

            var spiller3 = new Player() { Name = "Madsen" };
            Players.Add(spiller3);


            SaveChanges();


        }


    }
}

