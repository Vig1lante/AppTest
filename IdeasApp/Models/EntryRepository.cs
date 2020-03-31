using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Data.SqlClient;
using System.Data;

namespace IdeasApp.Models {
    class EntryRepository {
        private readonly SQLiteConnection Con;
        public EntryRepository(SQLiteConnection DbPath) => Con = DbPath;

        public List<Entry> ConvertResultToEntryList() {

            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            DataTable dataTable = new DataTable();
            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM Tasks", this.Con);
            adapter.SelectCommand = command;
            Con.Open(); adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(dataTable); Con.Close();

            var Entries = (from row in dataTable.AsEnumerable()
                           select new Entry {
                                  Category = row.Field<string>("Category"),
                                  TaskName = row.Field<string>("TaskName"),
                                  Deadline = row.Field<string>("Deadline"),
                                  Priority = row.Field<string>("Priority"),
                                  EstimatedTime = row.Field<decimal>("EstimatedTime"),
                              }).ToList();
            return Entries;
        }

        private Entry ConvertResultToEntry(DataSet resultSet, DataRow row) {
            // returns populated Entry list object with table results
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            DataTable dataTable = new DataTable();
            SQLiteCommand command = new SQLiteCommand($"SELECT {row} FROM {resultSet}", this.Con);
            adapter.SelectCommand = command;
            Con.Open(); adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(dataTable); Con.Close();

            var entry = new Entry {
                Category = row.Field<string>("Category"),
                TaskName = row.Field<string>("Task"),
                Deadline = row.Field<string>("Deadline"),
                Priority = row.Field<string>("Priority"),
                EstimatedTime = row.Field<int>("EstimatedTime")
            };
            return entry;
        }

        /* To do:
        + ReadByEntryDate
        + ReadByTask
        + ReadByPriority
        Misc methods
        */
    }
}
