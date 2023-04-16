using BreakfastApp.Models;
using SQLite;

namespace BreakfastApp
{
    public class BreakfastDatabase
    {
        SQLiteAsyncConnection Database;

        public BreakfastDatabase()
        {
        }

        private async Task Init()
        {
            SQLitePCL.Batteries.Init();

            if (Database is not null)
            {
                return;
            }

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await Database.CreateTableAsync<BreakfastDto>();
        }

        public async Task<List<BreakfastDto>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<BreakfastDto>().ToListAsync();
        }

        public async void SaveItemAsync(BreakfastDto item)
        {
            await Init();
            Database.InsertAsync(item).Wait();
        }

        public async void DeleteItemAsync(BreakfastDto item)
        {
            await Init();
            Database.DeleteAsync(item).Wait();
        }

        public async Task<int> DeleteAllAsync()
        {
            await Init();
            return await Database.DeleteAllAsync<BreakfastDto>();
        }
    }
}