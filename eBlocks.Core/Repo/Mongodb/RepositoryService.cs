using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using eBlocks.Assessment.Models.Attributes;
using eBlocks.Assessment.Models.Interface;
using eBlocks.Core.Interfaces;
using MongoDB.Driver;

namespace eBlocks.Core.Repo.Mongodb
{
    public class RepositoryService<TEntity>: IRepository<TEntity>
    where TEntity : class, IEntity
    
    {

        private readonly IMongoCollection<TEntity> _dbCollection;
       

        public RepositoryService(IDatabaseSettings  settings) 
        {
            var client = new MongoClient(settings.ConnString);
               var Db  = client.GetDatabase(name:settings.DatabaseName);
                _dbCollection = Db.GetCollection<TEntity>(GetCollectionName(typeof(TEntity)));
        }

       

        private static string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public async Task<bool> Add(TEntity entity)
        {
            try {

                await _dbCollection.InsertOneAsync(entity); 
                return true;
            }      
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try{
                  await _dbCollection.DeleteOneAsync(ent => ent.Id == id);  

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
              var results =  await _dbCollection.FindSync(filter).ToListAsync();
                return results;  
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
