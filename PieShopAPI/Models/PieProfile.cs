using AutoMapper;

namespace PieShopAPI.Models
{
    public class PieProfile: Profile
    {
        public PieProfile()
        {
            this.CreateMap<Pie, ListMini>();
            this.CreateMap<Pie, FilterMini>();
            this.CreateMap<Pie, DetailMini>();
        }
    }
}
