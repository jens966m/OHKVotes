using Core.DomainService;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Repos
{
    public class VoteRepo: IVoteRepo
    {
        private readonly MyAppContext _context;
        public VoteRepo(MyAppContext context)
        {
            _context = context;
        }

        public void ClearAllComments()
        {

            foreach (var vote in _context.Votes)
            {
                _context.Votes.Remove(vote);
            }
            _context.SaveChanges();

        }

        public void CreateComment(Player player, string comment)
        {
            Vote vote = new Vote() { Player = player, Comment = comment };
            _context.Votes.Add(vote);
            _context.SaveChanges();

        }
    }
}


