using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainService
{
    public interface IVoteRepo
    {
        void CreateComment(Player player, string comment);
        void ClearAllComments();
    }
}
