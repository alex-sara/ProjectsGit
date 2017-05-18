namespace Examples.SegmentedControl.FirstLook
{
    public class MenuItem
    {
        public MenuItem(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }
        public double Price { get; set; }
    }
}
