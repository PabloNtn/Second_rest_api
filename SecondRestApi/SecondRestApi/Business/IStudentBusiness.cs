using SecondRestApi.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SecondRestApi.Business
{
    public interface IStudentBusiness
    {
        ActionResult<Student> Create(Student student);
        ActionResult<Student> FindById(long id);
        ActionResult<List<Student>> FindAll();
        ActionResult<int> Delete(long id);
        ActionResult<Student> Update(Student student);
    }
}
