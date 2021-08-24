using SecondRestApi.Model;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace SecondRestApi.Repository.Implementations
{
    public class StudentRepositoryImplementation : IStudentRepository
    {

        public List<Student> FindAll()
        {
            List<Student> studentList = new();

            string conString = "User Id=SYSTEM;Password=257729;Data Source=localhost:1521/xe;";
            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        ControllerConnectionDataBase(con);

                        cmd.CommandText = "prALU_SEL_BUSCAR";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var student = new Student(
                                int.Parse(reader.GetString(0)),
                                reader.GetString(1),
                                reader.GetString(2),
                                DateTime.Parse(reader.GetString(3))
                                );
                            studentList.Add(student);
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
            return studentList;
        }

        public Student FindById(long id)
        {
            Student student = new();
            if (id > 0 || id < 100)
            {
                string conString = "User Id=SYSTEM;Password=257729;Data Source=localhost:1521/xe;";
                using (OracleConnection con = new OracleConnection(conString))
                {
                    using (OracleCommand cmd = con.CreateCommand())
                    {
                        try
                        {
                            ControllerConnectionDataBase(con);

                            cmd.CommandText = "prALU_SEL_BYID";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("id", id).Direction = ParameterDirection.Input;

                            OracleDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                student = new Student(
                                int.Parse(reader.GetString(0)),
                                reader.GetString(1),
                                reader.GetString(2),
                                DateTime.Parse(reader.GetString(3))
                                );
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
            }
            return student;
        }

        public Student Create(Student student)
        {
            string conString = "User Id=SYSTEM;Password=257729;Data Source=localhost:1521/xe;";
            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        ControllerConnectionDataBase(con);

                        cmd.CommandText = "prALU_INS";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("name", student.Alu_nm).Direction = ParameterDirection.Input;
                        cmd.Parameters.Add("tele", student.Alu_nr_tel).Direction = ParameterDirection.Input;
                        cmd.Parameters.Add("data", student.Alu_dt_nascimento).Direction = ParameterDirection.Input;

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
            return student;
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

                        cmd.CommandText = "prALU_UPD_LOG";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("id", id).Direction = ParameterDirection.Input;
                        cmd.Parameters.Add("DATA", DateTime.Now.ToString("dd/MM/yy HH:mm")).Direction = ParameterDirection.Input;

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

        public Student Update(Student student)
        {
            string conString = "User Id=SYSTEM;Password=257729;Data Source=localhost:1521/xe;";
            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        ControllerConnectionDataBase(con);

                        cmd.CommandText = "prALU_UPD";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("id", student.Alu_id).Direction = ParameterDirection.Input;
                        cmd.Parameters.Add("name", student.Alu_nm).Direction = ParameterDirection.Input;
                        cmd.Parameters.Add("tele", student.Alu_nr_tel).Direction = ParameterDirection.Input;
                        cmd.Parameters.Add("data", student.Alu_dt_nascimento).Direction = ParameterDirection.Input;

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
            return student;
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
