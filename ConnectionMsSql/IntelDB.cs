using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace ConnectionMsSql
{
    class IntelDB
    {
        private string _connectionString;
        private DbConnection _connection;
        private DbProviderFactory _factory;

        //----------------------------------------------------------------------
        public IntelDB(string ConnectionSttringName)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[ConnectionSttringName];

            _connectionString = settings.ConnectionString;

            _factory = DbProviderFactories.GetFactory(settings.ProviderName);
        }
        //----------------------------------------------------------------------
        public bool OpenConnection()
        {
            try
            {
                _connection = _factory.CreateConnection();
                _connection.ConnectionString = _connectionString;
                _connection.Open();
                return true;
            }
            catch (DbException)
            {
                return false;
            }
        }
        //----------------------------------------------------------------------
        public void CloseConnection()
        {
            if (_connection != null)
                _connection.Close();
        }
        //----------------------------------------------------------------------
        public List<Processor> GetAllProcessors()
        {
            try
            {
                //DbCommand command = _factory.CreateCommand();
                //command.Connection = _connection;

                //SqlCommand command = new SqlCommand();
                //command.Connection = _connection;

                DbCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM Processors";
                DbDataReader reader = command.ExecuteReader();
                List<Processor> processors = new List<Processor>();

                while (reader.Read())
                {
                    Processor processor = new Processor();
                    processor.Id = Convert.ToInt32(reader["Id"]);
                    processor.Family = Convert.ToString(reader["Family"]);
                    processor.Socket = Convert.ToString(reader["Socket"]);
                    processor.Generation = Convert.ToString(reader["Generation"]);
                    processor.Cores = Convert.ToByte(reader["Cores"]);
                    processor.CoreSpeed = Convert.ToDouble(reader["CoreSpeed"]);
                    processor.BusSpeed = Convert.ToDouble(reader["BusSpeed"]);
                    processor.Graphics = Convert.ToBoolean(reader["Graphics"]);
                    processor.Price = Convert.ToInt32(reader["Price"]);

                    processors.Add(processor);
                }

                reader.Close();
                return processors;
            }
            catch (DbException)
            {
                return null;
            }
        }
        //----------------------------------------------------------------------
        public Processor GetProcessorById(int Id)
        {
            try
            {
                DbCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM Processors WHERE Id = @id";

                DbParameter parameter = _factory.CreateParameter();
                parameter.ParameterName = "id";
                parameter.Value = Id;
                command.Parameters.Add(parameter);

                //DbParameter parameter = new SqlParameter("id", Id);
                //command.Parameters.Add(parameter);

                //command.Parameters.AddWithValue("id", Id); sql work

                DbDataReader reader = command.ExecuteReader();

                Processor processor = new Processor();

                if (reader.Read())
                {
                    processor.Id = Convert.ToInt32(reader["Id"]);
                    processor.Family = Convert.ToString(reader["Family"]);
                    processor.Socket = Convert.ToString(reader["Socket"]);
                    processor.Generation = Convert.ToString(reader["Generation"]);
                    processor.Cores = Convert.ToByte(reader["Cores"]);
                    processor.CoreSpeed = Convert.ToDouble(reader["CoreSpeed"]);
                    processor.BusSpeed = Convert.ToDouble(reader["BusSpeed"]);
                    processor.Graphics = Convert.ToBoolean(reader["Graphics"]);
                    processor.Price = Convert.ToInt32(reader["Price"]);
                }

                reader.Close();
                return processor;
            }
            catch (DbException)
            {
                return null;
            }
        }
        //----------------------------------------------------------------------
        public int GetAvgPrice()
        {
            try
            {
                //SqlCommand command = _connection.CreateCommand();
                //command.CommandText = "EXEC AvgPrice @res OUTPUT";

                //SqlParameter res = new SqlParameter();
                //res.ParameterName = "res";
                //res.SqlDbType = System.Data.SqlDbType.Int;
                //res.Direction = System.Data.ParameterDirection.Output;

                //command.Parameters.Add(res);
                //command.ExecuteNonQuery();

                //return Convert.ToInt32(res.Value);

                DbCommand command = _connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AvgPrice";

                DbParameter res = _factory.CreateParameter();
                res.ParameterName = "res";
                res.DbType = System.Data.DbType.Int32;
                res.Direction = System.Data.ParameterDirection.Output;

                //SqlParameter res = command.Parameters.Add("res", System.Data.SqlDbType.Int);

                command.Parameters.Add(res);
                command.ExecuteNonQuery();

                return Convert.ToInt32(res.Value);
            }
            catch (DbException)
            {
                return 0;
            }
        }
    }
}