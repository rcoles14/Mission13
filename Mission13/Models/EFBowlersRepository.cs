using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Models
{
    public class EFBowlersRepository : iBowlersRepository
    {
        private BowlingContext _context { get; set; }
        public EFBowlersRepository (BowlingContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;

        public void Add(Bowler bowler)
        {
            if (bowler.BowlerID == 0)
            {
                _context.Bowlers.Add(bowler);
            }
            _context.SaveChanges();
        }
        public void Update(Bowler b)
        {
            _context.Bowlers.Update(b);
            _context.SaveChanges();
        }
        public void Delete(Bowler p)
        {
            _context.Bowlers.Remove(p);
            _context.SaveChanges();
        }
    }
}
