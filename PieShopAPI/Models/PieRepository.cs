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
                return _appDbContext.Pies;
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek => _appDbContext.Pies.Where(pie => pie.IsPieOfTheWeek);

        public Pie GetPieById(int pieId)
        {
            return this.AllPies.FirstOrDefault(pie => pie.PieId == pieId);
        }
    }
}
