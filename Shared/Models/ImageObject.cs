namespace Misc.Shared.Models
{
    public class ImageObject
    {
        public int Id { get; set; }
        public string PageUrl { get; set; } = default!;
        public string? Type { get; set; }
        public string? Tags { get; set; }
        public string? PreviewUrl { get; set; }
        public int PreviewWidth { get; set; }
        public int PreviewHeight { get; set; }
        public string WebformatUrl { get; set; } = default!;
        public int WebformatWidth { get; set; }
        public int WebformatHeight { get; set; }
        public string? LargeImageUrl { get; set; }
        public string ImageUrl { get; set; } = default!;
        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }
        public int Views { get; set; }
        public int Downloads { get; set; }
        public int Likes { get; set; }
    }
}