using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService;
using Core.Entity;

namespace Core.ApplicationService.Services
{
    public class PlayerService : IPlayerService
    {
       private readonly IPlayerRepository repo;
        private readonly IVoteRepo voteRepo;
        public PlayerService(IPlayerRepository playerRepo, IVoteRepo voteRepoet)
        {
            voteRepo = voteRepoet;
            repo = playerRepo;
        }

        public void ClearAllVotes()
        {
            repo.ClearAllVotes();
        }

        public void CountOneUpVote(int id)
        {
            repo.Vote(id);
        }

        public Player CreatePlayer(string name)
        {
            return repo.Create(name);
        }

        public void DeletePlayer(int id)
        {

            repo.Delete(id);
                

        }

        public List<Player> GetAllPlayers()
        {
            var test = repo.GetAll().ToList();
            return test;
        }

        public List<Player> GetPlayersWithMostVotes()
        {
            var playerlist= repo.GetPlayersWithVotes().ToList();
            var sortedlist= playerlist.OrderByDescending(o => o.NumberOfVotes).ToList();

            return sortedlist;
        }
    }
}
