using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private DataContext dc;

        public PessoaController(DataContext context){
            this.dc = context;
        }

        [HttpPost("api")]  
        public async Task<ActionResult> cadastrar([FromBody] Pessoa pessoa){
            dc.p.Add(pessoa);
            await dc.SaveChangesAsync();

            return Created("Objeto pessoa", pessoa);

        }

        [HttpGet("api")]
        public async Task<ActionResult> listar(){
            var dados = await dc.p.ToListAsync();
            return Ok(dados);
        }
        [HttpGet("api/{id}")]
        public Pessoa filtrar(int id){
            Pessoa person = dc.p.Find(id);
            return person;
        }

        [HttpPut("api")]
        public async Task<ActionResult> editar([FromBody] Pessoa pessoa){
            dc.p.Update(pessoa);
            await dc.SaveChangesAsync();

            return Ok(pessoa);
        }

        [HttpDelete("api/{id}")]
        public async Task<ActionResult> remover(int id){
            Pessoa p = filtrar(id);
            if(p == null){
                return NotFound();
            }
            else{
                dc.p.Remove(p);
                await dc.SaveChangesAsync();
                return Ok();
            }
            
        }

        [HttpGet("oi")]
        public string oi(){
            return "hello world";
        }
        
    }
}