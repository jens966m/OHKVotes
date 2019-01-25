using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationService
{
    public interface IPlayerService
    {
        Player CreatePlayer(string name);
        List<Player> GetAllPlayers();
        List<Player> GetPlayersWithMostVotes();

        void ClearAllVotes();

        void CountOneUpVote(int id);

        void DeletePlayer(int id);
    }
}
