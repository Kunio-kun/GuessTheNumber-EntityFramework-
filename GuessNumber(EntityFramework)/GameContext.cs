using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber_EntityFramework_
{
    public class GameContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
    }
}
