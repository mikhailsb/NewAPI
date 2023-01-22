using Microsoft.AspNetCore.Mvc;
using NewAPI.Dominio.Interfaces;
using NewAPI.Dominio.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VinhoController : ControllerBase
    {
        private IVinhoServico _vinhoServicos;
        public VinhoController(IVinhoServico vinhoServico)
        {
            _vinhoServicos = vinhoServico;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var retorno = _vinhoServicos.Get();
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET api/<VinhoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var retorno = _vinhoServicos.Get(id);
                return Ok(retorno);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // POST api/<VinhoController>
        [HttpPost]
        public IActionResult Post([FromBody] VinhoPostRequest vinho)
        {
            try
            {
                _vinhoServicos.Post(vinho);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<VinhoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VinhoPutRequest vinho)
        {
            try
            {
                _vinhoServicos.Put(id, vinho);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<VinhoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _vinhoServicos.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
