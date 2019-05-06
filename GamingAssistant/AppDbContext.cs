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
        //public virtual DbSet<AcceptedChallenge> AcceptedChallenges { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Challenge> Challenges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //     modelBuilder.Entity<AcceptedChallenge>()
            //.HasKey(bc => new { bc.GameId, bc.ChallengeId });
            //     modelBuilder.Entity<AcceptedChallenge>()
            //         .HasRequired(bc => bc.Game)
            //         .WithMany(b => b.AcceptedChallenge)
            //         .HasForeignKey(bc => bc.GameId);
            //     modelBuilder.Entity<AcceptedChallenge>()
            //         .HasRequired(bc => bc.Challenge)
            //         .WithMany(c => c.AcceptedChallenge)
            //         .HasForeignKey(bc => bc.ChallengeId);
            // }
            modelBuilder.Entity<User>()
            .HasMany(p => p.Challenges)
            .WithMany(c => c.Users);
        }
    }
}
