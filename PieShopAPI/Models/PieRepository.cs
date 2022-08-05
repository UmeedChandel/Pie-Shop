using Microsoft.EntityFrameworkCore;

namespace PieShopAPI.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;
        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _appDbContext.Pies.Include(c =>c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek => _appDbContext.Pies.Where(pie => pie.IsPieOfTheWeek);

        public Pie GetPieById(int pieId)
        {
            return this.AllPies.FirstOrDefault(pie => pie.PieId == pieId);
        }

        // CRUD Operations

        public Pie InsertPie(Pie pies)
        {
            var entry = _appDbContext.Pies.Add(pies);
            _appDbContext.SaveChanges();
            return entry.Entity;
        }
        public Pie UpdatePie(Pie pies)
        {
            var entry = _appDbContext.Pies.Update(pies);
            _appDbContext.SaveChanges();
            return entry.Entity;
        }
        public Pie DeletePie(int pieId)
        {
            var pie = AllPies.FirstOrDefault(a => a.PieId == pieId);
            var entry = _appDbContext.Pies.Remove(pie);
            _appDbContext.SaveChanges();
            return entry.Entity;
        }
    }
}
