using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public class Vote
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public string Comment { get; set; }
    }
}
