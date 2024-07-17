﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Data;
using SchoolApplication.src.Dtos;
using SchoolApplication.src.Dtos.Student;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Models;

namespace SchoolApplication.src.Repositories.StudentRepo
{
    public abstract partial class StudentRepoBase : IStudentRepo
    {
        protected SchoolDb _context {  get; set; }

        public StudentRepoBase(SchoolDb context)
        {
            _context = context;
        }

        public IQueryable<Student> Get(StudentQueryObject paginationObjectQuery)
        {
            IQueryable<Student> res = _context.Students
               .Include(s => s.Courses)
               .ThenInclude(sc => sc.Course)
               .Include(s => s.School)
               .Include(s => s.Scholarship)
               .AsQueryable();
       
            //apply filters
            res = ApplyFilters(res, paginationObjectQuery);

            return res;

        }

        public async Task<Student?> GetById(int id)
        {
            return await _context.Students
                .Include(s => s.Courses)
                .ThenInclude(sc => sc.Course)
                .Include(s => s.School)
                .Include(s => s.Scholarship)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student?> Create(Student input)
        {
            var created = await _context.Students.AddAsync(input);
            if (created == null)
            {
                return null;
            }
            await _context.SaveChangesAsync();
            return input;
        }

        public async Task<bool> Delete(int id)
        {
            var res = await _context.Students.FindAsync(id);
            if(res == null)
                return false;
            
            _context.Students.Remove(res);
            await _context.SaveChangesAsync();
            
            return true;
        }

    }
}