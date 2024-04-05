/*****************************************************************************
*  Author : Gatreh
*  Created On : Fri Apr 05 2024
*
*  This template was created by Gatreh.
*  Right now it can only handle being 1 level deep in the workspace folder.
*****************************************************************************/
using MongoDB.Driver;
using MongoDB.Bson;
using Inlämning3Docker.Services;
using Inlämning3Docker.Models;

namespace Inlämning3Docker.Services;
public class MongoDbToDoService : IDbService
{
    private readonly IMongoCollection<DbItem> _dbItems;

    public MongoDbToDoService(IConfiguration config)
    {
        var mongoDbSettings = config.GetSection("MongoDbSettings");
        var client = new MongoClient(mongoDbSettings["ConnectionString"]);
        var database = client.GetDatabase(mongoDbSettings["DatabaseName"]);
        _dbItems = database.GetCollection<DbItem>(mongoDbSettings["CollectionName"]);
    }

    public async Task<DbItem> CreateAsync(DbItem newItem)
    {
        await _dbItems.InsertOneAsync(newItem);
        return newItem;
    }

    public async Task DeleteAsync(string id)
    {
        await _dbItems.DeleteOneAsync(item => item.Id == id);
    }

    public async Task<IEnumerable<DbItem>> GetAllAsync()
    {
        return await _dbItems.Find(_ => true).ToListAsync();
    }
}