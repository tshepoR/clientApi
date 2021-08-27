using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using client.Dtos;
using client.Entities;

namespace client.BusinessLogicLayer
{
    public interface IClientBll
    {
        Task<ReponseDto<Client>> AddClientAsync(Client clientData);
        Task<ReponseDto<List<Client>>> GetAllAsync();
        Task<ReponseDto<Client>> GetClientByIdAsync(string id);
        Task<ReponseDto<Client>> UpdateClientAsync(string id,Client clientData);
    }
}
