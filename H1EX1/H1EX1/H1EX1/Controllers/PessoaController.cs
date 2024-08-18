using H1EX1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ex1_H1.Controllers {

    [ApiController]
    [Route("API/PESSOA")]
    public class PessoaController : ControllerBase {

        [HttpPost]
        [Route("CalcularIMC")]
        public IActionResult CalcularIMC(Pessoa _pessoa) {

            if (_pessoa.Altura <= 0 || _pessoa.Peso <= 0) {
                return BadRequest("Altura e peso devem ser maiores que zero.");
            }

            double imc = _pessoa.Peso / (_pessoa.Altura * _pessoa.Altura);
            imc = Math.Round(imc, 2);

            return Ok($"Seu imc é: {imc}");

        }
        [HttpPost]
        [Route("ConsultarTabelaIMC")]

        [HttpPost("consulta-tabela-imc")]
        public IActionResult ConsultaTabelaIMC([FromBody] double imc) {
            string descricao;

            if (imc < 18.5) {
                descricao = "Abaixo do peso";
            }
            else if (imc >= 18.5 && imc < 24.9) {
                descricao = "Peso normal";
            }
            else if (imc >= 25.0 && imc < 29.9) {
                descricao = "Sobrepeso";
            }
            else if (imc >= 30.0 && imc < 34.9) {
                descricao = "Obesidade Grau I";
            }
            else if (imc >= 35.0 && imc < 39.9) {
                descricao = "Obesidade Grau II";
            }
            else {
                descricao = "Obesidade Grau III";
            }

            var resultado = new {
                IMC = imc,
                Descricao = descricao
            };

            return Ok($"IMC: {resultado}");
        }
    }
}