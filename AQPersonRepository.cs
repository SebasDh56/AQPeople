using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQPeople.Models;

namespace AQPeople
{
    public class AQPersonRepository
    {
        string _dbPath;
        private SQLiteConnection conn;

        public string StatusMessage { get; set; }

        // TODO: Add variable for the SQLite connection

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<AQPerson>();
        }

        public AQPersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                // TODO: Call Init()
                Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");


                // TODO: Insert the new person into the database
                result = conn.Insert(new AQPerson { Name = name });

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public List<AQPerson> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<AQPerson>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<AQPerson>();
        }
    }
}
