using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using client.Entities;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;

namespace client.DataAccessLayer
{
    public class ClientDal : IClientDal
    {
        private readonly IDocumentClient _dbClient;
        private readonly IConfiguration _config;
        private readonly string databaseId;
        private readonly string collectionId = "clients";

        public ClientDal(IDocumentClient dbClient, IConfiguration config)
        {
            _dbClient = dbClient;
            _config = config;
            databaseId = _config["Database_Id"];

            buildDatabase().Wait();
        }

        private async Task buildDatabase()
        {
            await _dbClient.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseId });
            await _dbClient.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(databaseId), new DocumentCollection { Id = collectionId });
        }

        public async Task<Client> AddClientAsync(Client clientData)
        {
             await _dbClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseId, collectionId), clientData);

            return clientData;
        }

        public  Task<List<Client>> GetAllAsync()
        {
            var data = _dbClient.CreateDocumentQuery<Client>(UriFactory.CreateDocumentCollectionUri(databaseId, collectionId)).ToList();
            return Task.FromResult(data);
        }

        public Task<Client> GetClientByIdAsync(string id)
        {
            var data = _dbClient.CreateDocumentQuery<Client>(UriFactory.CreateDocumentCollectionUri(databaseId, collectionId),
                new FeedOptions { MaxItemCount = 1 }).ToList().FirstOrDefault(x => x.IdNumber == id);
            return Task.FromResult(data);
        }

        public async Task<Client> UpdateClientAsync(string id, Client clientData)
        {

            await _dbClient.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseId, collectionId,id) ,clientData);

            return clientData;
        }
    }
}
