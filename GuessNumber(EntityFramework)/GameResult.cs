using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber_EntityFramework_
{
    public class GameResult : BaseEntity
    {
        public int Turns { get; set; }
        public DateTime Date { get; set; }
    }
}
