using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using client.BusinessLogicLayer;
using client.Dtos;
using client.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Extensions.Logging;

namespace client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
  
        private readonly ILogger<ClientController> _logger;
        private readonly IClientBll _clientBll;

        public IDocumentClient _client { get; }
        public ClientController(ILogger<ClientController> logger,IClientBll clientBll)
        {
            _logger = logger;
            _clientBll = clientBll;
        }

        [HttpPost]
        public async Task<ActionResult<Client>> post([FromBody] Client clientData)
        {
            try
            {
                var data = await _clientBll.AddClientAsync(clientData);

                data.Success = true;

                return Ok(data);
                
            }
            catch (Exception ex)
            {
                return null;
              
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _clientBll.GetAllAsync();

                data.Success = true;

                return Ok(data);

            }
            catch (Exception ex)
            {

                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(string id)
        {
            try
            {
                var data = await _clientBll.GetClientByIdAsync(id);

                data.Success = true;

                return Ok(data);

            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> Put(string id, [FromBody] Client clientData)
        {
            try
            {
                var data = await _clientBll.UpdateClientAsync(id, clientData);

                data.Success = true;

                return Ok(data);

            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);

            }
        }
    }
}
