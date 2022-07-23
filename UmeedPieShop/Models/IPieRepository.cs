namespace UmeedPieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; } // <<== Read Only 
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int pieId);

    }
}
