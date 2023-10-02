namespace Domain.Models
{
    public partial class Photo
    {
        public decimal Id { get; set; }
        public string? Url { get; set; }
        public bool Ismain { get; set; }
        public string? Publicid { get; set; }
        public decimal? Userid { get; set; }

        public virtual User? User { get; set; }
    }
}
