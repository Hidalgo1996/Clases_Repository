using ConsoleApp1.Models;
using ConsoleApp1.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Metadata;



class Program
{
    static async Task Main(string[] args)
    {
        //Estudiantes:
        //await guardarEstudianteAsync();
        //await agregarEstudiante();
        //await consultarEstudiante();
        //await consultarEstudiantes();
        //await consultarEstudiantesFunciones();
        //await modificarEstudiante();
        //await eliminarEstudiante();

        //Direccion:
        //await guardarEstudianteYdireccion();
        //await consultarDirecciones();
        //await consultarDireccion2();
        //await guardarEstudianteYdireccionTransaction();

        //Curso:
        //await guardarCurso();
        //await guardarEstudianteCurso();
        //await consultarAlumnosyCursos();
    }

    //guardarEstudianteAsync();
    public static async Task guardarEstudianteAsync()
    {
        Console.WriteLine("Guardar Estudiantes desde la clase Repository");
        
        EstudianteRepository estudianteRepository= new EstudianteRepository();
        Student std = new Student();
        std.Name = "Lola";
        std.LastName = "Perez";
        await estudianteRepository.guardarEstudiante(std);
    }
    //guardarCurso
    public static async Task guardarCurso()
    {
        CursoRepository cursoRepository = new CursoRepository();
        await cursoRepository.guardarCurso();
    }
    //guardarEstudianteCurso
    public static void guardarEstudianteCurso()
    {
        Console.WriteLine("Guardar EstudianteCurso");
        CursoRepository cursoRepository = new CursoRepository();
        await cursoRepository.guardarEstudianteCurso();
    }
    //guardarEstudianteYdireccion
    public static async Task guardarEstudianteYdireccion()
    {
        Console.WriteLine("Metodo agregar estudiante y direccion");
        DireccionRepository direccionRepository = new DireccionRepository();
        await direccionRepository.guardarEstudianteYdireccion();
    }
    //guardarEstudianteYdireccionTransaction
    public static void guardarEstudianteYdireccionTransaction()
    {
        Console.WriteLine("Metodo agregar estudiante y direccion");
        DireccionRepository direccionRepository = new DireccionRepository();
        await direccionRepository.guardarEstudianteYdireccion();
    }
    //consultarDirecciones
    public static void consultarDirecciones()
    {
        Console.WriteLine("Consultar direcciones");
        DireccionRepository direccionRepository = new DireccionRepository();
        await direccionRepository.guardarEstudianteYdireccion();
    }
    //consultarDireccion2
    public static void consultarDireccion2()
    {
        Console.WriteLine("Consultar direccion por Id, metodo 2");
        DireccionRepository direccionRepository = new DireccionRepository();
        await direccionRepository.guardarEstudianteYdireccion();
    }
    //consultarAlumnosyCursos()
    public static void consultarAlumnosyCursos()
    {
        Console.WriteLine("Consultar un Alumnos y sus cursos con Include");
        CursoRepository cursoRepository = new CursoRepository();
        await cursoRepository.consultarAlumnosyCursos();
    }
    //agregarEstudiante
    public static async Task agregarEstudiante()
    {
        Console.WriteLine("Metodo agregar estudiante");

        EstudianteRepository estudianteRepository = new EstudianteRepository();
        
        Student std = new Student();
        std.Name = "Pedro";
        std.LastName = "Narvaez";

        await estudianteRepository.agregarEstudiante(std);
    }
    //consultarEstudiantes
    public static void consultarEstudiantes()
    {
        Console.WriteLine("Metodo consultar estudiantes");
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        await estudianteRepository.consultarEstudiantes();
    }
    //consultarEstudiante
    public static void consultarEstudiante()
    {
        Console.WriteLine("Metodo consultar estudiante por Id");
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        await estudianteRepository.consultarEstudiante();
    }
    //modificarEstudiante
    public static void modificarEstudiante()
    {
        Console.WriteLine("Metodo modificar estudiante");
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        await estudianteRepository.modificarEstudiante();
    }
    //eliminarEstudiante
    public static async void eliminarEstudiante()
    {
        Console.WriteLine("Metodo eliminar estudiante");
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        await estudianteRepository.eliminarEstudiante();
    }
    //consultarEstudiantesFunciones
    public static void consultarEstudiantesFunciones()
    {
        Console.WriteLine("Metodo eliminar estudiante");
        EstudianteRepository estudianteRepository = new EstudianteRepository();
        await estudianteRepository.guardarEstudiante();
    }
}