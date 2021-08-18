using SecondRestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace SecondRestApi.Services.Implementations
{
    public class StudentServiceImplementation : IStudentService
    {
        private volatile int count;

        public Student Create(Student student)
        {
            return student;
        }

        public void Delete(long id)
        {

        }

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
                        OpenConnectionDataBase(con);

                        cmd.CommandText = "student";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var student = new Student(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                            studentList.Add(student);
                        }
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        CloseConnectionDataBase(con);
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

        public Student Update(Student student)
        {
            return student;
        }
        //private Person MockPerson(int i)
        //{
        //    return new Person
        //    {
        //        FirstName = "Person Name" + i,
        //        LastName = "Person LastName" + i,
        //        Adress = "Some Adress" + i,
        //    };
        //}

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        void OpenConnectionDataBase(OracleConnection connection)
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {

            }
        }
        void CloseConnectionDataBase(OracleConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
