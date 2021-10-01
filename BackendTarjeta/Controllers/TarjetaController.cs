﻿using BackendTarjeta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendTarjeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {

        private readonly AplicationDBContext _context;

        public TarjetaController(AplicationDBContext context)
        {
            _context = context;
        }
        // GET: api/<TarjetaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listarTarjetas = await _context.tarjetaCredito.ToListAsync();
                return Ok(listarTarjetas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }

        // GET api/<TarjetaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TarjetaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                _context.Add(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(tarjeta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // PUT api/<TarjetaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                if (id!=tarjeta.Id)
                {
                    return NotFound(new{ message = "id No es valido" });
                }
                _context.Update(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { message= "La Tarjeta fue actulizada con exito" });
            
            }
            catch (Exception ex)
            {
              return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TarjetaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarjeta = await _context.tarjetaCredito.FindAsync(id);
                if (tarjeta==null)
                {
                    return NotFound(new { message = "id No es valido" });
                }
                _context.tarjetaCredito.Remove(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La Tarjeta fue eliminada con exito" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
