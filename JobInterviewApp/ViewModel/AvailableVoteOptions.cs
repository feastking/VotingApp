using System;
using System.Collections.Generic;
using JobInterviewApp.Models;
using System.Web;

namespace JobInterviewApp.ViewModel
{
    public class AvailableVoteOptions
    {
        public IEnumerable<Candidate> Candidates { get; set; }
        public IEnumerable<Voter> Voters { get; set; }

        public int candidateID { get; set; }
        public int voterID { get; set; }
    }
}