using System;
using System.Collections.Generic;

namespace Core.Entity
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfVotes { get; set; }

        public IEnumerable<Vote> Votes { get; set; }
    }
}
