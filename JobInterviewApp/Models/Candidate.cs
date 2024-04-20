using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobInterviewApp.Models
{
    public class Candidate
    {
        public int ID { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }
        
        public int Votes { get; set; }
        public IEnumerable<SelectListItem> VotersTest { get; set; }

        public virtual ICollection<Voter> Voters { get; set; }
    }
}