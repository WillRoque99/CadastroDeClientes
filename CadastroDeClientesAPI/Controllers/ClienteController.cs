using CadastroDeClientes.Application.Dtos;
using CadastroDeClientes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeClientesAPI.Controllers
{
    [Route("cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IApplicationServiceCliente _applicationServiceCliente;

        public ClienteController(IApplicationServiceCliente ApplicationServiceCliente)
        {
            _applicationServiceCliente = ApplicationServiceCliente;
        }

        //get api/value
        [HttpGet]

        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceCliente.GetAll());
        }

        [HttpGet("{codigo}")]

        public ActionResult<string> Get(int codigo)
        {
            return Ok(_applicationServiceCliente.GetById(codigo));
        }

        // POST api/values
        [HttpPost]

        public ActionResult Post([FromBody] ClienteViewModel clienteViewModel)
        {
            try
            {
                if (clienteViewModel == null)
                    return NotFound();

                var JaExisteCNPJ = _applicationServiceCliente.GetAll().FirstOrDefault(x => x.CNPJ == clienteViewModel.CNPJ);

                if (JaExisteCNPJ != null)
                    return Ok("CNPJ já utilizado em outro cadastro!");


                _applicationServiceCliente.Add(clienteViewModel);
                return Ok("Cliente Cadastrado com  sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] ClienteViewModel clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                    return NotFound();

                _applicationServiceCliente.Update(clienteDTO);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{codigo}")]
        public ActionResult Delete(int codigo)
        {
            try
            {
                if (codigo <= 0)
                    return NotFound();

                _applicationServiceCliente.Remove(codigo);
                return Ok("Cliente Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }        
    }
}