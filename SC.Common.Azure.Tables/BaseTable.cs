using Azure.Data.Tables;

namespace SC.Common.AzureTables
{
  public class BaseTable<T> where T : class, ITableEntity, new()
  {
    private readonly string _tableName;
    private readonly string _connectionString;
    protected TableClient _tableClient;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="connectionString"></param>
    /// <param name="tableName"></param>
    public BaseTable(string connectionString, string tableName)
    {
      _connectionString = connectionString;
      _tableName = tableName;
    }

    public async Task<TableClient> GetTableClient()
    {
      if (_tableClient == null)
      {
        TableServiceClient tableService = new TableServiceClient(_connectionString);
        await tableService.CreateTableIfNotExistsAsync(_tableName);
        _tableClient = tableService.GetTableClient(_tableName);
      }
      return _tableClient;
    }

    public async Task InsertOrUpdateEntityAsync(ITableEntity tableEntity)
    {
      var tableClient = await GetTableClient();
      var res = await tableClient.UpsertEntityAsync(tableEntity);
      if (res.Status != 204)
      {
        throw new AzureTableException("Error while Upserting an entity");
      }
    }
  }
}