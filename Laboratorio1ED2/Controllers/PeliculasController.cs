using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibreriaDeClasesED2;
using Laboratorio1ED2.Helpers;
using Laboratorio1ED2.Models;

namespace Laboratorio1ED2.Controllers
{
    delegate int DelegadoString(string Tarea1, string Tarea2);
    delegate int DelegadoObjeto(object Tarea1, string Tarea2);
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        Peliculas Pelicula = new Peliculas();
        public PeliculasController(IWebHostEnvironment env)
        {
            Singleton.Intance.Way = env.ContentRootPath + "//testapi.txt";
        }

        [HttpPost]
        public IActionResult CrearArbol ([FromBody] int Degree) 
        {
            try
            {
                Singleton.Intance.Arbol = new ArbolPrueba<Peliculas>(Degree);
                return StatusCode(201);
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("populate")]
        public IActionResult Agregar([FromBody] List<Peliculas> list) 
        {
            try
            {
                DelegadoString ComparacionPeliculas = new DelegadoString(Pelicula.CompareToString);
                foreach (var item in list)
                {
                    Singleton.Intance.Arbol.Insert(item, ComparacionPeliculas);
                }
                return StatusCode(201);
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("populate/{Titulo}")]
        public IActionResult Eliminar(string Titulo) 
        {
            try
            {
                DelegadoObjeto ComparacionObjeto = new DelegadoObjeto(Pelicula.CompareToObjeto);
                Singleton.Intance.Arbol.Delete(Titulo,Singleton.Intance.Arbol.Raiz,ComparacionObjeto);
                return StatusCode(201);
            }
            catch 
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public IActionResult LimpiarArbol() 
        {
            try
            {
                Singleton.Intance.Arbol.EliminarArbol();
                return StatusCode(201);
            }
            catch 
            {
                return StatusCode(500);
            }
        }
    }
}