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
    public class ConductorController : ControllerBase
    {


        private readonly TRANSITOContext _context;


        public ConductorController(TRANSITOContext context)
        {
            _context = context;
        }


        // GET: api/<MatriculaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConductorDTO>>> Get()
        {


            try
            {
                var conductor = await _context.Conductors.Select(c => new ConductorDTO() {
                    Id = c.Id,
                    Identificacion = c.Identificacion,
                    Nombre = c.Nombre,
                    Apellidos = c.Apellidos,
                    Direccion = c.Direccion,
                    Telefono = c.Telefono,
                    MatriculaId = c.MatriculaId,
                    MatriculaRegistrada = c.Matricula.Numero,
                    FechaExpedicion = c.Matricula.FechaExpedicion

                }).ToListAsync();
                if (conductor == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductor;
                }

              
            }
            catch (Exception exe)
            {
                throw new Exception(exe.Message);
            }
        }




        // GET api/<ConductorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConductorDTO>> Get(int id)
        {
            try
            {
                    var conductor = await _context.Conductors.Select(x =>
                    new ConductorDTO
                    {
                        Id = x.Id,
                        Identificacion = x.Identificacion,
                        Nombre = x.Nombre,
                        Apellidos = x.Apellidos,
                        Direccion = x.Direccion,
                        Telefono = x.Telefono,
                        MatriculaId = x.MatriculaId,
                        MatriculaRegistrada = x.Matricula.Numero,
                        FechaExpedicion = x.Matricula.FechaExpedicion
                    }).FirstOrDefaultAsync(x => x.Id == id);
                   
                  
                    if (conductor == null)
                    {
                        return NotFound();
                     }
                    else
                    {
                        return conductor;
                    }
                
            }
            catch (Exception exe)
            {
                throw new Exception(exe.Message);
            }
        }



        // POST api/<ConductorController>
        [HttpPost]
        public async Task<Conductor> Post(ConductorDTO conductorDTO)
        {
           

                try
                {
                    var conductorCrear = new Conductor();
                    conductorCrear.Id = conductorDTO.Id;
                    conductorCrear.Identificacion = conductorDTO.Identificacion;
                    conductorCrear.Nombre = conductorDTO.Nombre;
                    conductorCrear.Apellidos = conductorDTO.Apellidos;
                    conductorCrear.Direccion = conductorDTO.Direccion;
                    conductorCrear.Telefono = conductorDTO.Telefono;
                    conductorCrear.MatriculaId = conductorDTO.MatriculaId;


                    _context.Conductors.Add(conductorCrear);

                        await _context.SaveChangesAsync();
                        return conductorCrear;
                    }

                    catch (Exception exe)
                    {
                        throw new Exception(exe.Message);
                }
            }



        // PUT api/<ConductorController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(ConductorDTO conductorDTO)
        {


            try
            {

                var infoConductor = await _context.Conductors.FirstOrDefaultAsync(v => v.Id == conductorDTO.Id);

                infoConductor.Id = conductorDTO.Id;
                infoConductor.Identificacion = conductorDTO.Identificacion;
                infoConductor.Nombre = conductorDTO.Nombre;
                infoConductor.Apellidos = conductorDTO.Apellidos;
                infoConductor.Direccion = conductorDTO.Direccion;
                infoConductor.Telefono = conductorDTO.Apellidos;
                infoConductor.MatriculaId = conductorDTO.MatriculaId;


                _context.Entry(infoConductor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return HttpStatusCode.Accepted;
            }
            catch (Exception exe)
            {
                throw new Exception(exe.Message);
            }

        }

        // DELETE api/<ConductorController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {

                var conductor = new Conductor()
                {
                    Id = id
                };
                _context.Conductors.Attach(conductor);
                _context.Conductors.Remove(conductor);
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
