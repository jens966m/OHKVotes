using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainService
{
    public interface IPlayerRepository
    {
        Player Create(string name);
        IEnumerable<Player> GetAll();
        void ClearAllVotes();
        void Vote(int id);
        void Delete(int id);
    }
}
