using GamingAssistant.Models.ComponentsModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingAssistant
{
    class AppDbContext : DbContext
    {
        public AppDbContext()
           : base("DbConnection")
        { }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<UserChallenge> UserChallenges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { }
    }
}
