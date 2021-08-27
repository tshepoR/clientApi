using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using client.DataAccessLayer;
using client.Dtos;
using client.Entities;

namespace client.BusinessLogicLayer
{
    public class ClientBll : IClientBll
    {
        private readonly IClientDal _clientDal;

        public ClientBll(IClientDal clientDal)
        {
            _clientDal = clientDal;
        }
        public  async Task<ReponseDto<Client>> AddClientAsync(Client clientData)
        {
           var response =  await _clientDal.AddClientAsync(clientData);

            return new ReponseDto<Client> { payload = response };
        }

        public async Task<ReponseDto<List<Client>>> GetAllAsync()
        {
            var response = await _clientDal.GetAllAsync();

            return new ReponseDto<List<Client>> { payload = response };
        }

        public async Task<ReponseDto<Client>> GetClientByIdAsync(string id)
        {
            var response = await _clientDal.GetClientByIdAsync(id);

            return new ReponseDto<Client> { payload = response };
        }

        public async Task<ReponseDto<Client>> UpdateClientAsync(string id, Client clientData)
        {
            var response = await _clientDal.UpdateClientAsync(id, clientData);

            return new ReponseDto<Client> { payload = response };
        }
    }
}
