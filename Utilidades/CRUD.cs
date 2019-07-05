using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DatabaseTools.SQLite
{

    public class CRUD
    {
        // Properties
        string _path;
        public string Path { get { return _path; } set { this._path = value; } }

        // Default constructor
        public CRUD(string path)
        {
            _path = path;
        }

        // Method for executing a non-return query with configuring the error message
        public void voidQuery(string query,string sqliteErrorMsg, string sqliteDefaultMsg, MessageBoxButtons buttons, MessageBoxIcon icon, string connectionString)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand(query,conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            } catch (SQLiteException ex)
            {
                if (MessageBox.Show($"{sqliteErrorMsg}, deseja ver o log do erro?","Erro",buttons,icon) == DialogResult.Yes)
                {
                    MessageBox.Show($"Erro:{ex.ToString()}");
                }
            } catch (Exception ex)
            {
                if (MessageBox.Show($"{sqliteDefaultMsg}, deseja ver o log do erro?", "Erro", buttons, icon) == DialogResult.Yes)
                {
                    MessageBox.Show($"Erro:{ex.ToString()}");
                }
            }
        }

        // Methods for checking if there is a record alrealdy
        public bool CheckRegistryExistente(string table, string column, string value, string connectionString)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand($"SELECT * FROM {table} WHERE {column} = '{value}'", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (value.Equals(reader.GetString(reader.GetOrdinal(column))));
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
