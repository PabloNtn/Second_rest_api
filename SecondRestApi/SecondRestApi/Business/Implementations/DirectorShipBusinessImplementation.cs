using SecondRestApi.Model;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace SecondRestApi.Business.Implementations
{
    public class DirectorShipBusinessImplementation : IDirectorShipBusiness
    {
        public List<DirectorShip> FindAll()
        {
            List<DirectorShip> directorList = new();

            string conString = "User Id=SYSTEM;Password=257729;Data Source=localhost:1521/xe;";
            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        ControllerConnectionDataBase(con);

                        cmd.CommandText = "selectDirector";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var director = new DirectorShip(
                                int.Parse(reader.GetString(0)),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3));
                            directorList.Add(director);
                        }
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        ControllerConnectionDataBase(con);
                    }
                }
            }
            return directorList;
        }
        public DirectorShip Create(DirectorShip director)
        {
            string conString = "User Id=SYSTEM;Password=257729;Data Source=localhost:1521/xe;";
            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        ControllerConnectionDataBase(con);

                        cmd.CommandText = "insertDirector";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("name", director.Dir_userName).Direction = ParameterDirection.Input;

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        ControllerConnectionDataBase(con);
                    }
                }
            }
            return director;
        }
        public void Delete(long id)
        {
            string conString = "User Id=SYSTEM;Password=257729;Data Source=localhost:1521/xe;";
            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        ControllerConnectionDataBase(con);

                        cmd.CommandText = "deleteDirector";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("id", id).Direction = ParameterDirection.Input;

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        ControllerConnectionDataBase(con);
                    }
                }
            }
        }
        void ControllerConnectionDataBase(OracleConnection connection)
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                else
                    connection.Open();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
