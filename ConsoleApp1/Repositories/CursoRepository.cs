using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repositories
{
    public class CursoRepository
    {
        private readonly SchoolContext _context = new SchoolContext();

        public async Task guardarCurso()
        {
            Console.WriteLine("Guardar Curso");
            SchoolContext _context = new SchoolContext();
            Course course = new Course();

            course.CourseName = "Tercero";
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task guardarEstudianteCurso()
        {
            SchoolContext _context = new SchoolContext();
            StudentCourse stdCourse = new StudentCourse();
            /*
            Student std = new Student();
            std = _context.Students.Find(1);

            Course course = new Course();
            course = _context.Courses.Find(1);
            */
            stdCourse.CourseId = 3;//course.CourseId;
            stdCourse.StudentId = 3; //std.StudentId;
            /*
            stdCourse.Student = std;
            stdCourse.Course = course;
            */
            _context.StudentCourses.Add(stdCourse);
            await _context.SaveChangesAsync();
        }

        public async Task consultarAlumnosyCursos()
        {

            SchoolContext _context = new SchoolContext();
            List<StudentCourse> std;
            std = _context.StudentCourses
                .Where(x => x.StudentId == 3)
                .Include(x => x.Course)
                .Include(x => x.Student)
                .ToList();


            Console.WriteLine("Cursos del estudiante " + std[0].StudentId + " " + std[0].Student.Name);

            foreach (var item in std)
            {
                Console.WriteLine("Curso: " + item.CourseId + " " + item.Course.CourseName);
            }
        }
    }
}