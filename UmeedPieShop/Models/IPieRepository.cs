namespace UmeedPieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; } 
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int pieId);

        public Pie InsertPie(Pie pies);
        public Pie UpdatePie(Pie pies);
        public Pie DeletePie(int pieId);

    }
}
