using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using client.Entities;

namespace client.DataAccessLayer
{
    public interface IClientDal
    {
        Task<Client> AddClientAsync(Client clientData);
        Task<List<Client>> GetAllAsync();
        Task<Client> GetClientByIdAsync(string name);
        Task<Client> UpdateClientAsync(string id, Client clientData);
    }
}
