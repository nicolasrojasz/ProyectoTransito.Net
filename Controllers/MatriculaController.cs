using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoConduccion.DTOS;
using ProyectoConduccion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoConduccion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
   
            private readonly TRANSITOContext _context;


            public MatriculaController(TRANSITOContext context)
            {
                _context = context;
            }


            // GET: api/<MatriculaController>
            [HttpGet]
            public async Task<ActionResult<IEnumerable<MatriculaDTO>>> Get()
            {

                try
                {
                    var matriculas = await _context.Matriculas.Select(m =>new MatriculaDTO()
                    {
                            Id = m.Id,
                            Numero = m.Numero,
                            FechaExpedicion =m.FechaExpedicion,
                            FechaExpiracion = m.FechaExpiracion,
                            Activo = m.Activo
                                                    
                    }).ToListAsync();

                    return matriculas;
                }
                catch (Exception exe)
                {
                    throw new Exception(exe.Message);
                }
            }




            // GET api/<MatriculaController>/5
            [HttpGet("{id}")]
        public async Task<ActionResult<Matricula>> Get(int id)
        {
            try
            {

                var matricula = await _context.Matriculas.FindAsync(id);
                var matriculaDto = new MatriculaDTO();
                matriculaDto.Id = matricula.Id;
                return matricula;
            }
            catch (Exception exe)
            {
                throw new Exception(exe.Message);
            }
        }



        // POST api/<MatriculaController>
        [HttpPost]
        public async Task<Matricula> Post(MatriculaDTO matriculaDto)
        {

            try
            {
                var matriculaCrear = new Matricula();
                matriculaCrear.Id = matriculaDto.Id;
                matriculaCrear.Numero = matriculaDto.Numero;
                matriculaCrear.FechaExpedicion = matriculaDto.FechaExpedicion;
                matriculaCrear.FechaExpiracion = matriculaDto.FechaExpiracion;

                _context.Matriculas.Add(matriculaCrear);

                await _context.SaveChangesAsync();
                return matriculaCrear;
            }

            catch (Exception exe)
            {
                throw new Exception(exe.Message);
            }

         }

        // PUT api/<MatriculaController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(MatriculaDTO matriculaDto)
        {
            try
            {
                    var infoMatricula = await _context.Matriculas.FirstOrDefaultAsync(v => v.Id == matriculaDto.Id);
                    infoMatricula.Id = matriculaDto.Id;
                    infoMatricula.Numero = matriculaDto.Numero;
                    infoMatricula.FechaExpedicion = matriculaDto.FechaExpiracion;
                    infoMatricula.FechaExpiracion = infoMatricula.FechaExpiracion;
                    infoMatricula.Activo = matriculaDto.Activo;

                    _context.Entry(infoMatricula).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return HttpStatusCode.Accepted;
                

            }

            catch (Exception exe)
            {
                throw new Exception(exe.Message);
            }

        }

        // DELETE api/<MatriculaController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {

                var matricula = new Matricula()
                {
                    Id = id
                };
                _context.Matriculas.Attach(matricula);
                _context.Matriculas.Remove(matricula);
                await _context.SaveChangesAsync();
                return HttpStatusCode.OK;
            }
            
            
            catch (Exception exe)
            {
                throw new Exception(exe.Message);
            }

        }
    }
}
