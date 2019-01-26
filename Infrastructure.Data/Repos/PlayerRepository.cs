using Core.DomainService;
using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.Repos
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly MyAppContext _context;
        public PlayerRepository(MyAppContext context)
        {
            _context = context;
        }

        public void ClearAllVotes()
        {

            foreach (var item in _context.Players)
            {
                item.NumberOfVotes = 0;
            }
            _context.SaveChanges();
        }

        public Player Create(string name)
        {
            Player player = new Player() { Name = name };
            _context.Players.Add(player);
            _context.SaveChanges();
            return player;
        }



        public void Delete(int id)
        {
            Player player = new Player() { Id = id };
            Player DeletedPLayer = _context.Players.Remove(player).Entity;
            _context.SaveChanges();
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Players.AsNoTracking();
        }

        public IEnumerable<Player> GetPlayersWithVotes()
        {
            var test = _context.Players.Include(x => x.Votes);
            return _context.Players.
                Include(x => x.Votes);


        }

        public void Vote(int id)
        {
            _context.Players.Where(x => x.Id == id).FirstOrDefault().NumberOfVotes++;
            _context.SaveChanges();

        }
    }
}

