using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using System.Threading.Tasks;

namespace MauiApp2
{
    public static class DatabaseHere
    {
        //SQLite connection
        private static SQLiteAsyncConnection _database;

        public static async Task InitializeDatabaseAsync()
        {
            // Database is already initialized
            if (_database != null)
                return; 

            // Get the path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "chimein.db");

            // Create a new SQLite connection
            _database = new SQLiteAsyncConnection(databasePath);

            // Create the tables if they don't exist
            await _database.CreateTableAsync<User>();
            await _database.CreateTableAsync<Mood>();
        }

        public static SQLiteAsyncConnection GetDatabase()
        {
            // Ensure the database is initialized before returning it
            if (_database == null)
                throw new InvalidOperationException("Database not initialized. Call InitializeDatabaseAsync() first.");
            return _database;
        }
    }
}
