using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationService;
using Core.DomainService;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;


namespace OHKUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerService service;
        private readonly IVoteRepo _voteRepo;
        public PlayerController(IPlayerService playerService, IVoteRepo voteRepo)
        {
            service = playerService;
            _voteRepo = voteRepo;
        }


        ////GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<Player>> GetAllPlayers()
        //{
        //    var tem = service.GetAllPlayers();
        //    return tem;
        //}

        [HttpGet]
        public IActionResult GetAllPlayers()
        {
            var tem = service.GetAllPlayers();

            return View(tem);
        }


        [HttpGet("winner")]
        public IActionResult GetAllWinners()

        {
           var tempt = service.GetPlayersWithMostVotes();
            return View(tempt);
        }




        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromForm] string name)
        {

            if (name != null && name.Length<=20)
            {
                var test = service.CreatePlayer(name);
                return RedirectToAction("GetAllPlayers");
            }
            return BadRequest("over 0 og under 20 karakterer på navn");
        }

        [HttpPost]
        [Route("deleteMember")]
        public ActionResult DeleteByPost([FromForm] int id)
        {
            try
            {
            service.DeletePlayer(id);
             return RedirectToAction("GetAllPlayers");

            }
            catch (Exception e)
            {
                var test = e.Message;

                return BadRequest("something went wrong - nulstil aftemning inden slet af spiller");
            }

        }
        [HttpPost]
        [Route("ClearAllVotes")]
        public ActionResult ClearAllVotesByPost()
        {
            try
            {
                service.ClearAllVotes();
                _voteRepo.ClearAllComments();
                return RedirectToAction("GetAllPlayers");

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }

        }

        [HttpPost]


        [Route("VoteForMember")]
        public ActionResult VoteByPost([FromForm] int id, [FromForm] string comment)
        {
            try
            {
                Player player = new Player() { Id = id };
                service.CountOneUpVote(id);
                _voteRepo.CreateComment(player, comment);
                return RedirectToAction("GetAllPlayers");

            }
            catch (Exception)
            {
                return BadRequest("no Vote!");
            }

        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id)
        {
            service.CountOneUpVote(id);
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete()
        {
            service.ClearAllVotes();
            _voteRepo.ClearAllComments();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            service.DeletePlayer(id);
            return null;
        }

    }
}


