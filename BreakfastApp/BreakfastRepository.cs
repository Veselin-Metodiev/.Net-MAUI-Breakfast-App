using BreakfastApp.Models;
using SQLite;

namespace BreakfastApp
{
    public class BreakfastRepository
    {
        private readonly SQLiteConnection _database;

        public BreakfastRepository()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Breakfast.db");
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<BreakfastDto>();
        }

        public List<BreakfastDto> GetAllItems() =>
            _database.Table<BreakfastDto>().ToList();

        public int Create(BreakfastDto entity) =>
            _database.Insert(entity);

        public int Delete(int id) =>
            _database.Delete(_database.Table<BreakfastDto>()
                .FirstOrDefault(b => b.Id == id));

        public int Reset() =>
            _database.DeleteAll<BreakfastDto>();
    }
}
