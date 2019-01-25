using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationService;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;


namespace OHKUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerService service;
        public PlayerController(IPlayerService playerService)
        {
            service = playerService;
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

            if (name != null)
            {
                var test = service.CreatePlayer(name);
                return RedirectToAction("GetAllPlayers");
            }
            else return null;
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
            catch (Exception)
            {

                return BadRequest("something went wrong");
            }

        }
        [HttpPost]
        [Route("ClearAllVotes")]
        public ActionResult ClearAllVotesByPost()
        {
            try
            {
                service.ClearAllVotes();
                return RedirectToAction("GetAllPlayers");

            }
            catch (Exception)
            {
                return BadRequest("Somethin went wrong");
            }

        }

        [HttpPost]
        [Route("VoteForMember")]
        public ActionResult VoteByPost([FromForm] int id)
        {
            try
            {
                service.CountOneUpVote(id);
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
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            service.DeletePlayer(id);
            return null;
        }

    }
}


