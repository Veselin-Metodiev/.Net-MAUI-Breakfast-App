namespace BreakfastApp.Models
{
    public class Breakfast
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Uri Image { get; set; }

        public List<string> Savory { get; set; }

        public List<string> Sweet { get; set; }
    }
}
