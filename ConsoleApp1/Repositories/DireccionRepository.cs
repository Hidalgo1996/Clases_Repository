using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repositories
{
    public class DireccionRepository
    {
        private readonly SchoolContext _context = new SchoolContext();

        public async Task guardarEstudianteYdireccion()
        {
            Student std = new Student();
            StudentAddress stdAddress = new StudentAddress();

            std.Name = "Ciri";
            _context.Students.Add(std);
            await _context.SaveChangesAsync();

            stdAddress.Address1 = "direccion 1";
            stdAddress.Address2 = "direccion 2";
            stdAddress.StudentID = std.StudentId;
            stdAddress.City = "gye";
            stdAddress.State = "ecu";
            stdAddress.Student = std;

            _context.StudentAddresses.Add(stdAddress);

            await _context.SaveChangesAsync();
        }

        public async Task consultarDirecciones()
        {
            //Console.WriteLine("Metodo consultar estudiante por Id");
            SchoolContext _context = new SchoolContext();
            List<StudentAddress> listaDirecciones;
            listaDirecciones = _context.StudentAddresses
                .Include(x=> x.Student)
                .ToList();
        
                foreach (var item in listaDirecciones)
                {
                    Console.WriteLine("Codigo:"+ item.Student.StudentId +
                    " Nombre: " + item.Student.Name + 
                    " Direccion:" + item.Address1);
                }
        }
        public async Task consultarDireccion2()
        {
            SchoolContext _context = new SchoolContext();
            StudentAddress address = new StudentAddress();
            address = _context.StudentAddresses
                .Single(x => x.StudentID == 16);


            _context.Entry(address)
                .Reference(x => x.Student)
                .Load();

            /*
            _context.Entry(address)
              .Collection(x => x.Student)
              .Load();
            */

            Console.WriteLine("Codigo: " + address.Student.StudentId +
                    " Nombre: " + address.Student.Name +
                    " Direccion: " + address.Address1);

        }

        public async Task guardarEstudianteYdireccionTransaction()
        {
            SchoolContext _context = new SchoolContext();
            Student std = new Student();
            StudentAddress stdAddress = new StudentAddress();
            var dbContextTransaction = _context.Database.BeginTransaction();

            try
            {
                std.Name = "Karina";
                _context.Students.Add(std);
                _context.SaveChanges();

                stdAddress.Address1 = "direccion 1";
                stdAddress.Address2 = "direccion 2";
                stdAddress.StudentID = std.StudentId;
                stdAddress.City = "gye";
                stdAddress.State = "ecu";

                _context.StudentAddresses.Add(stdAddress);

                _context.SaveChanges();
                dbContextTransaction.Commit();
                Console.WriteLine("Datos guardados con exito");
            }
            catch (Exception e)
            {
                dbContextTransaction.Rollback();
                Console.WriteLine("Error " + e.ToString());
            }
        }
    }
}