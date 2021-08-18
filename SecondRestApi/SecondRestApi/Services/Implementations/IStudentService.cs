﻿using SecondRestApi.Model;
using System.Collections.Generic;

namespace SecondRestApi.Services.Implementations
{
    public interface IStudentService
    {
        Student Create(Student student);
        //Person FindById(long id);
        List<Student> FindAll();
        void Delete(long id);
        Student Update(Student student);
    }
}
