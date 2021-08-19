using SecondRestApi.Model;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace SecondRestApi.Services.Implementations
{
    public class StudentServiceImplementation : IStudentService
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

                        cmd.CommandText = "addStudent";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var student = new Student(reader.GetString(0), reader.GetString(1), DateTime.Parse(reader.GetString(2)));
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

        //public Person FindById(long id)
        //{

        //    //return new Person
        //    //{
        //    //    FirstName = "Pablo",
        //    //    LastName = "Monteiro",
        //    //    Adress = "Rua catatau",
        //    //};
        //}

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

                        cmd.CommandText = "insertStudent";
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

        public void Delete(String name)
        {
            string conString = "User Id=SYSTEM;Password=257729;Data Source=localhost:1521/xe;";
            using (OracleConnection con = new OracleConnection(conString))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        ControllerConnectionDataBase(con);

                        cmd.CommandText = "deleteStudent";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("name", name).Direction = ParameterDirection.Input;

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

                        cmd.CommandText = "updateStudent";
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
