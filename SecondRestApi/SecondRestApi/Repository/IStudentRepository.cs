using Microsoft.AspNetCore.Mvc;
using SecondRestApi.Model;
using System.Collections.Generic;

namespace SecondRestApi.Repository
{
    public interface IStudentRepository
    {
        Student Create(Student student);
        Student FindById(long id);
        List<Student> FindAll();
        ActionResult<int> Delete(long id);
        Student Update(Student student);
    }
}
