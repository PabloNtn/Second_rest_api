using SecondRestApi.Model;
using System.Collections.Generic;

namespace SecondRestApi.Repository
{
    public interface IStudentRepository
    {
        Student Create(Student student);
        //Person FindById(long id);
        List<Student> FindAll();
        void Delete(string name);
        Student Update(Student student);
    }
}
