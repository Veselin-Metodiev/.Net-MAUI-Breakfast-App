namespace BreakfastApp.Models
{
    public class Breakfast
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Uri Image { get; set; }

        public List<string> Savory { get; set; }

        public List<string> Sweet { get; set; }
    }
}
