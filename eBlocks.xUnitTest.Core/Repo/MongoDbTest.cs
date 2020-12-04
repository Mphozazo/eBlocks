using System;
using Xunit;


namespace eBlocks.xUnitTest.Core.Repo
{
    /// <summary>
    ///  Testing all related to MongoDb CRUD operation and connection .
    /// </summary>
    /// <remarks>
    ///   - DB connection test
    ///   - DB read Test
    ///   - DB write Test
    ///   - DB delete test
    /// </remarks>
    public class MongoDbTest :IDisposable 
    {
        
         //private readonly eBlocks.Core.Repo.Mongodb.DatabaseSettings _dbSettings;
        public MongoDbTest() {}
        public void Dispose()
        {
        
        }
        #region Database Connection Test of any Entity  
         [Fact]
            public void IsDatabaseConnected() 
            {
                

                
   

            }

        [Fact]
        public void TestName()
        {
        //Given
        
        //When
        
        //Then
        }
        #endregion

        #region CRUD Testing 

        #endregion

    }
}
