namespace Misc.Shared.Models
{
    public class PixabayObject
    {
        public int Total { get; set; }
        public int TotalHits { get; set; }
        public IEnumerable<ImageObject>? Hits { get; set; }   
    }
}