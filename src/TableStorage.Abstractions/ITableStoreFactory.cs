﻿using Microsoft.WindowsAzure.Storage.Table;

namespace TableStorage.Abstractions
{
    public interface ITableStoreFactory
    {
        ITableStore<T> CreateTableStore<T>(string tableName, string storageConnectionString) where T : class, ITableEntity, new();
        ITableStore<T> CreateTableStore<T>(string tableName, string storageConnectionString, int retries,
            double retryWaitTimeInSeconds, int maxNumberOfConnections, bool ensureTableExists = true) where T : class, ITableEntity, new();
    }
}