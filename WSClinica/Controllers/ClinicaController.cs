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
        public class ClinicaController : ControllerBase
        {
            //Inyección de dependencias Inicia


            // Propiedades

            private readonly DBClinicaContext context;


            //constructor

            public ClinicaController(DBClinicaContext context)
            {
                this.context = context;
            }


            //Inyección de dependecia Termina


            
            //GET: api/clinica
            [HttpGet]

            public ActionResult<IEnumerable<Clinica>> Get()
            {
                return context.Clinicas.ToList();
            }

            //GET BY ID
            //GET: api/clinica/5
            [HttpGet("{id}")]
            public ActionResult<Clinica> GetById(int id)
            {
                Clinica clinica = (from a in context.Clinicas
                               where a.Id == id
                               select a).SingleOrDefault();
                return clinica;
            }

            //Post api/clinica
            [HttpPost]

            public ActionResult Post(Clinica clinica)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(clinica);
                }
                context.Clinicas.Add(clinica);
                context.SaveChanges();
                return Ok();
            }

            //Put
            //Put api/clinica/2

            [HttpPut("{id}")]

            public ActionResult Put(int id, [FromBody] Clinica clinica)
            {
                if (id != clinica.Id)
                {
                    return BadRequest();
                }
                context.Entry(clinica).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                return Ok();
            }

            //Delete  api/clinica/3

            [HttpDelete("{id}")]

            public ActionResult<Clinica> Delete(int id)
            {
                var clinica = (from a in context.Clinicas
                             where a.Id == id
                             select a).SingleOrDefault();
                if (clinica == null)
                {
                    return NotFound();
                }
                context.Clinicas.Remove(clinica);
                context.SaveChanges();
                return clinica;


            }

        }
    }
