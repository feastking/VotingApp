using JobInterviewApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JobInterviewApp.DatabaseConn
{
    public class VotingContext : DbContext
    {

        public VotingContext() : base("VotingContext")
        {
        }

        public DbSet<Voter> Voter { get; set; }
        public DbSet<Candidate> Candidate { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}