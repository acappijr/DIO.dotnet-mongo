using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Infectados.Domain.Collections;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infectados.Data.Servicos
{
    public class InfectadoRepository : IInfectadoRepository
    {
        MongoDBContext _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoRepository(MongoDBContext mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        public async Task<Infectado> ObterInfectadoPorIdAsync(string id)
        {
            return await _infectadosCollection.Find(Builders<Infectado>.Filter.Eq("_id", new ObjectId(id)))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Infectado>> ObterTodosInfectadosAsync()
        {
            return await _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToListAsync();
        }

        public async Task SalvarInfectadoAsync(Infectado infectado)
        {
            await _infectadosCollection.InsertOneAsync(infectado);
        }

    }
}
