using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobInterviewApp.DatabaseConn;
using JobInterviewApp.Models;
using JobInterviewApp.ViewModel;

namespace JobInterviewApp.Controllers
{
    public class HomeController : Controller
    {
        private VotingContext db = new VotingContext();

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new AvailableVoteOptions
            {
                Candidates = db.Candidate,
                Voters = db.Voter.Where(x => x.hasVoted == false)
            };

            ViewBag.AvailableVoters = new SelectList(db.Voter.Where(x => x.hasVoted == false), "ID", "Name");
            ViewBag.AvailableCandidates = new SelectList(db.Candidate, "ID", "Name");

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(AvailableVoteOptions viewModel)
        {
            if (ModelState.IsValid && viewModel.candidateID != 0 && viewModel.voterID != 0)
            {
                //var voterToUpdate = db.Voter.Find(viewModel.voterID);

                using (var ctx = new VotingContext())
                {
                    int noOfVotersUpdated = ctx.Database.ExecuteSqlCommand("Update Voter set hasVoted = 1 where ID = @id", new SqlParameter("@id", viewModel.voterID));
                    int noOfCandidatesUpdated = ctx.Database.ExecuteSqlCommand("Update Candidate set Votes = Votes + 1 where ID = @id", new SqlParameter("@id", viewModel.candidateID));
                }
            }

            return RedirectToAction("Index");
        }

        //private void PopulateAvailableVoteOptions()
        //{
        //    var votersAvailable = db.Voter.Where(x => x.hasVoted == false);
        //    var candidatesAvailable = db.Candidate;

        //    var viewModel = new List<AvailableVoteOptions>();


        //        viewModel.Add(new AvailableVoteOptions
        //        {
        //            Candidates = candidatesAvailable,
        //            Voters = votersAvailable
        //        });

        //    ViewBag.VotersAvailable = db.Voter.Where(x => x.hasVoted == false).ToList();
        //    ViewBag.CandidatesAvailable = db.Candidate.ToList();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //db.Entry(candidate).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Update(string VoterSelected, string CandidateSelected)
        //{
        //    //string haha = Request.Form["Voters"].ToString();
        //    if (ModelState.IsValid)
        //    {
        //        //db.Entry(candidate).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //public ActionResult Update(string voterID, string candidateID)
        //{
        //    //string haha = Request.Form["Voters"].ToString();
        //    if (ModelState.IsValid)
        //    {
        //        //db.Entry(candidate).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //public ActionResult Update(AvailableVoteOptions viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //db.Entry(candidate).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Update([Bind(Include = "ID,Name,Votes")] Candidate candidate, [Bind(Include = "ID,Name,hasVoted")] Voter voter)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //db.Entry(candidate).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(candidate);
        //}


        //GET: Voter
        //public ActionResult Index()
        //{
        //    return View(db.Voter.ToList());
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Voter/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Name,hasVoted")] Voter voter)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Voter.Add(voter);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(voter);
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}