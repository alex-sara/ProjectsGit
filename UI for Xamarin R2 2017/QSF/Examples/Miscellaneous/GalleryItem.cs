namespace Examples
{
    public class GalleryItem
    {
        public GalleryItem(string key, string image)
        {
            this.Image = image;
            this.Key = key;
        }

        public string Image { get; set; }
        public string Key { get; set; }
    }
}
