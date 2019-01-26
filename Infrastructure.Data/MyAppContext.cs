using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class MyAppContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Vote> Votes { get; set; }



        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

            //Database.EnsureDeleted();
            Database.EnsureCreated();
          // AddSampleData();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Player>()
                .HasMany(x => x.Votes);

        }


        private void AddSampleData()
        {



            var spiller = new Player() { Name = "Danny" };

      
            var spiller2 = new Player() { Name = "Jens" };
            Players.Add(spiller2);

            var spiller3 = new Player() { Name = "Madsen" };
            Players.Add(spiller3);


            SaveChanges();


        }


    }
}

