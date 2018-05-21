using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectionMsSql
{
    class IntelDB
    {
        private string ConnectionString = "Server=(local);Database=IntelCPU;Trusted_Connection=True;"; //2E-2F

        private SqlConnection _connection;
        //----------------------------------------------------------------------
        public bool OpenConnection()
        {
            try
            {
                _connection = new SqlConnection(ConnectionString);
                _connection.Open();
                return true;
            }
            catch (SqlException)
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
                //SqlCommand command = new SqlCommand();
                //command.Connection = _connection;

                SqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM Processors";
                SqlDataReader reader = command.ExecuteReader();
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
            catch (SqlException)
            {
                return null;
            }
        }
        //----------------------------------------------------------------------
        public Processor GetProcessorById(int Id)
        {
            try
            {
                SqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT * FROM Processors WHERE Id = @id";

                SqlParameter parameter = new SqlParameter("id", Id);
                command.Parameters.Add(parameter);
                //command.Parameters.AddWithValue("id", Id); sql work

                SqlDataReader reader = command.ExecuteReader();

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
            catch (SqlException)
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

                SqlCommand command = _connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "AvgPrice";

                SqlParameter res = command.Parameters.Add("res", System.Data.SqlDbType.Int);
                res.Direction = System.Data.ParameterDirection.Output;
                command.ExecuteNonQuery();

                return Convert.ToInt32(res.Value);
            }
            catch (SqlException)
            {
                return 0;
            }
        }
    }
}