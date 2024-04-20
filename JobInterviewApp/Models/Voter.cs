using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobInterviewApp.Models
{
    public class Voter
    {
        public int ID { get; set; }
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Name cannot be longer than 10 characters.")]
        public string Name { get; set; }
        public bool hasVoted { get; set; }
        public IEnumerable<SelectListItem> VotersAvailable { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}