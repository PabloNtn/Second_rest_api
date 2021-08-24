using SecondRestApi.Model;
using SecondRestApi.Repository;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SecondRestApi.Business.Implementations
{
    public class StudentBusinessImplementation : IStudentBusiness
    {

        private IStudentRepository _StudentRepository;


        public StudentBusinessImplementation(IStudentRepository StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }

        public ActionResult<List<Student>> FindAll()
        {
            return _StudentRepository.FindAll();
        }

        public ActionResult<Student> FindById(long id)
        {
            return _StudentRepository.FindById(id);
        }

        public ActionResult<Student> Create(Student student)
        {
            return _StudentRepository.Create(student);
        }

        public void Delete(long id)
        {
            _StudentRepository.Delete(id);
        }

        public ActionResult<Student> Update(Student student)
        {
            return _StudentRepository.Update(student);
        }
    }
}
