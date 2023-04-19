using SQLite;

namespace BreakfastApp.Models
{
    [Table(nameof(Breakfast))]
    public class BreakfastDto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUri { get; set; }

        public string Savory { get; set; }

        public string Sweet { get; set; }
    }
}
