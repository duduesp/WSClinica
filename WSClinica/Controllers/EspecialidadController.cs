using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSClinica.Data;
using WSClinica.Models;

namespace WSClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        //Inyección de dependencias Inicia


        // Propiedades

        private readonly DBClinicaContext context;


        //constructor

        public EspecialidadController(DBClinicaContext context)
        {
            this.context = context;
        }


        //Inyección de dependecia Termina



        //GET: api/especialidad
        [HttpGet]

        public ActionResult<IEnumerable<Especialidad>> Get()
        {
            return context.Especialidades.ToList();
        }



        //GET BY ID
        //GET: api/especialidad/5

        [HttpGet("{id}")]
        public ActionResult<Especialidad> GetById(int id)
        {
            Especialidad especialidad= (from a in context.Especialidades
                               where a.Id == id
                               select a).SingleOrDefault();
            return especialidad;
        }

        //Post api/especialidad
        [HttpPost]

        public ActionResult Post(Especialidad especialidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(especialidad);
            }
            context.Especialidades.Add(especialidad);
            context.SaveChanges();
            return Ok();
        }

        //Put
        //Put api/especialidad/2

        [HttpPut("{id}")]

        public ActionResult Put(int id, [FromBody] Especialidad especialidad)
        {
            if (id != especialidad.Id)
            {
                return BadRequest();
            }
            context.Entry(especialidad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        //Delete  api/especialidad/3

        [HttpDelete("{id}")]

        public ActionResult<Especialidad> Delete(int id)
        {
            var especialidad = (from a in context.Especialidades
                           where a.Id == id
                           select a).SingleOrDefault();
            if (especialidad == null)
            {
                return NotFound();
            }
            context.Especialidades.Remove(especialidad);
            context.SaveChanges();
            return especialidad;


        }

    }
}
