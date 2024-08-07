﻿using Microsoft.AspNetCore.Mvc;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Interfaces
{
    public interface IStudentRepo
    {
        public IQueryable<Student> Get(StudentQueryObject query);
        public Task<Student?> GetById(int id);
        public Task<Student?> Create(Student input);
        public Task<bool> Delete(int id);
    }
}
