using Microsoft.AspNetCore.Mvc;
using NewAPI.Dominio.Interfaces;
using NewAPI.Dominio.Modelos;
using NewAPI.Dominio.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CervejaController : ControllerBase
    {
        private ICervejaServico _cervejaServico;
        public CervejaController(ICervejaServico cervejaServico)
        {
            _cervejaServico = cervejaServico;
        }
        // GET: api/<CervejaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var retorno = _cervejaServico.Get();
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
            
        }

        // GET api/<CervejaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var retorno = _cervejaServico.Get(id);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }

        // POST api/<CervejaController>
        [HttpPost]
        public IActionResult Post([FromBody] CervejaPostRequest cerveja)
        {
            try
            {
                _cervejaServico.Post(cerveja);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }

        // PUT api/<CervejaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CervejaPutRequest cerveja)
        {
            try
            {
                _cervejaServico.Put(id, cerveja);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // DELETE api/<CervejaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _cervejaServico.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }
    }
}
