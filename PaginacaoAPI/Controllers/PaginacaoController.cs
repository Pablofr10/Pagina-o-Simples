using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaginacaoAPI.Interfaces;
using PaginacaoAPI.Model;

namespace PaginacaoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaginacaoController : ControllerBase
    {
        private readonly IDataRepository _servico;

        public PaginacaoController(IDataRepository servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public  IEnumerable<Pessoa> Get([FromQuery] PaginacaoDto paginacao)
        {
            var result =   _servico.GetAll(paginacao);
            return result;

        }

        [HttpPost]
        public async Task<IActionResult> Post(Pessoa model)
        {
            var pessoa = new Pessoa
            {
                Nome = model.Nome,
                Email = model.Email
            };

            _servico.Add(pessoa);

            if (await _servico.SaveChanges())
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("adicionarMuitos")]
        public async Task<IActionResult> Post(List<Pessoa> model)
        {
            var pessoas = new List<Pessoa>();
            foreach (var item in model)
            {
                var pessoa = new Pessoa
                {
                    Nome = item.Nome,
                    Email = item.Email
                };
                pessoas.Add(pessoa);
            }
           

            _servico.AddRange(pessoas);

            if (await _servico.SaveChanges())
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
