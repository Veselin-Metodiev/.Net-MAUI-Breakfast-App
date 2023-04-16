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

        public List<BreakfastDto> List()
        {
            return _database.Table<BreakfastDto>().ToList();
        }

        public int Create(BreakfastDto entity)
        {
            return _database.Insert(entity);
        }

        public int Update(BreakfastDto entity)
        {
            return _database.Update(entity);
        }

        public int Delete(BreakfastDto entity)
        {
            return _database.Delete(entity);
        }
    }
}
