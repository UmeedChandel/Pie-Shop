using AutoMapper;

namespace UmeedPieShop.Models
{
    public class PieProfile: Profile
    {
        public PieProfile()
        {
            this.CreateMap<Pie, PieMini>();
        }
    }
}
