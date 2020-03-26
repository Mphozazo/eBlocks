using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using eBlocks.Assessment.Models.Interface;
using eBlocks.Core.Interfaces;
using MongoDB.Driver;

namespace eBlocks.Core.Repo.Mongodb
{
    public class RepositoryService<TEntity, TMongodbSettings> : IRepository<TEntity>
    where TEntity : class, IEntity
    where TMongodbSettings : DatabaseSettings
    {

         private readonly IMongoCollection<TEntity> _dbCollection;    
         private IMongoDatabase db;

        public RepositoryService(TMongodbSettings _settings) 
        {
            var client = new MongoClient(_settings.ConnectionStr);
                Db  = client.GetDatabase(_settings.DatabaseName);   
            _dbCollection = Db.GetCollection<TEntity>(_settings.CollectionName); 
        }

        public IMongoDatabase Db { get => db; set => db = value; }

        public async Task<bool> Add(TEntity Entity)
        {
            try {

                await _dbCollection.InsertOneAsync(Entity); 
                return true;
            }      
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(string Id)
        {
            try{
                  await _dbCollection.DeleteOneAsync(ent => ent.Id == Id);  

                  return true;  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         public async Task<bool> Delete(TEntity entity)
        {
            try{
                  await _dbCollection.DeleteOneAsync(ent => ent.Id == entity.Id);  
                  return true;  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> FindById(string id)
        {
           try{
               return await _dbCollection.Find<TEntity>(entity => entity.Id == id).FirstOrDefaultAsync();   
                
           }
           catch (Exception ex)
           {
               throw ex;
           }
        }

        public async Task<TEntity> FindByName(string name)
        {
            try{
               return await _dbCollection.Find<TEntity>(entity => entity.Name  == name).FirstOrDefaultAsync();   
                
           }
           catch (Exception ex)
           {
               throw ex;
           }
        }

        public async Task<List<TEntity>> GetAll()
        {
            try{

              FilterDefinition<TEntity> filter = FilterDefinition<TEntity>.Empty;
              return await _dbCollection.FindSync(filter).ToListAsync();   
                
           }
           catch (Exception ex)
           {
               throw ex;
           }
        }

        public async Task<bool> Update(TEntity Entity)
        {
             try{
                await _dbCollection.ReplaceOneAsync(entity => entity.Id == Entity.Id,Entity);   
               return true; 
           }
           catch (Exception ex)
           {
               throw ex;
           }
        }
    }
}
