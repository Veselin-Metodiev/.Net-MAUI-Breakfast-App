using BreakfastApp.Models;
using SQLite;

namespace BreakfastApp
{
    public class BreakfastRepository
    {
        private readonly SQLiteConnection database;

        public BreakfastRepository()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Breakfast.db");
            database = new SQLiteConnection(dbPath);
            database.CreateTable<BreakfastDto>();
        }

        public List<BreakfastDto> GetAllItems() =>
            database.Table<BreakfastDto>().ToList();

        public int Create(BreakfastDto entity) =>
            database.Insert(entity);

        public int Delete(int id) =>
            database.Delete(database.Table<BreakfastDto>()
                .FirstOrDefault(e => e.Id == id));

        public int Reset() =>
            database.DeleteAll<BreakfastDto>();

        public BreakfastDto GetItem(int id) =>
            database.Table<BreakfastDto>()
                .FirstOrDefault(e => e.Id == id);

        public int Update(BreakfastDto entity) =>
            database.Update(entity);
    }
}
