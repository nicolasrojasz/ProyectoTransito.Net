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
    public class SancioneController : ControllerBase
    {


        private readonly TRANSITOContext _context;


        public SancioneController(TRANSITOContext context)
        {
            _context = context;
        }



        // GET: api/<SancioneController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SancioneDTO>>> Get()
        {
            try
            {
                var sanciones = await _context.Sanciones.Select(s => new SancioneDTO()
                {
                    Id = s.Id,
                    Fecha = s.Fecha,
                    ConductorId = s.ConductorId,
                    NombreConductor = s.Conductor.Nombre
                }).ToListAsync();

                return sanciones;
            }
            catch (Exception exe)
            {
                throw new Exception(exe.Message);
            }
        }


        // GET api/<SancioneController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SancioneDTO>> Get(int id)
        {
            try
            {
                var sancione = await _context.Sanciones.Select(x =>
                new SancioneDTO
                {
                    Id = x.Id,
                    Fecha = x.Fecha,
                    ConductorId = x.ConductorId,
                    NombreConductor = x.Conductor.Nombre
                }).FirstOrDefaultAsync(x => x.Id == id);
                    if (sancione == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return sancione;
                    }
                
            }
            catch (Exception exe)
            {
                throw new Exception(exe.Message);
            }
        }

        // POST api/<SancioneController>
        [HttpPost]
        public async Task<Sancione> Post(SancioneDTO sancioneDTO)
        {


            try
            {
                var sancionCrear = new Sancione();
                sancionCrear.Id = sancioneDTO.Id;
                sancionCrear.Fecha = sancioneDTO.Fecha;
                sancionCrear.ConductorId = sancioneDTO.ConductorId;
               

                _context.Sanciones.Add(sancionCrear);

                await _context.SaveChangesAsync();
                return sancionCrear;
            }

            catch (Exception exe)
            {
                throw new Exception(exe.Message);
            }

        }


        // PUT api/<SancioneController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(SancioneDTO sancioneDTO)
        {
            try
            {
                var infoSancion = await _context.Sanciones.FirstOrDefaultAsync(v => v.Id == sancioneDTO.Id);
                infoSancion.Id = sancioneDTO.Id;
                infoSancion.Fecha = sancioneDTO.Fecha;
                infoSancion.ConductorId = sancioneDTO.ConductorId;

                _context.Entry(infoSancion).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return HttpStatusCode.Accepted;


            }

            catch (Exception exe)
            {
                throw new Exception(exe.Message);
            }

        }

        // DELETE api/<SancioneController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {

                var sancione = new Sancione()
                {
                    Id = id
                };
                _context.Sanciones.Attach(sancione);
                _context.Sanciones.Remove(sancione);
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
