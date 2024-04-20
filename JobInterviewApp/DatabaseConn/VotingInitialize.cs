using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using JobInterviewApp.Models;

namespace JobInterviewApp.DatabaseConn
{
    public class VotingInitialize : System.Data.Entity.DropCreateDatabaseIfModelChanges<VotingContext>
    {
        protected override void Seed(VotingContext context)
        {
            var voters = new List<Voter>
            {
            new Voter{Name="Peppa",hasVoted=false,},
            new Voter{Name="Rumcajs",hasVoted=false,}
            };

            voters.ForEach(s => context.Voter.Add(s));
            context.SaveChanges();

            var candidates = new List<Candidate>
            {
            new Candidate{Name="Johnny Bravo",Votes=0,},
            new Candidate{Name="Pluto",Votes=0,}
            };
            candidates.ForEach(s => context.Candidate.Add(s));
            context.SaveChanges();
        }
    }
}