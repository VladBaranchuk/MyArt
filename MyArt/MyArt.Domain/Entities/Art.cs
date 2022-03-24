using MyArt.Domain.Enums;

namespace MyArt.Domain.Entities
{
    public class Art
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrightColor { get; set; }
        public string MutedColor { get; set; }
        public string DarkColor { get; set; }
        public int ShareCount { get; set; }
        public int Price { get; set; }
        public EMonth Month { get; set; }
        public string Year { get; set; }
        public ESellingAvailability SellingAvailability { get; set; }
        public EVisible Visible { get; set; }
        public EModeration Moderation { get; set; }
        public EType Type { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
