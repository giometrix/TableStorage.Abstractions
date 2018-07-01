﻿using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using TableStorage.Abstractions.Tests.Helpers;
using Xunit;

namespace TableStorage.Abstractions.Tests.Store
{
    public partial class TableStoreAsyncTests
    {
        [Fact]
        public void delete_async_with_null_record_throws_exception()
        {
            // Arrange
            // Act
            Func<Task> act = async () => await _tableStorage.DeleteAsync(null as TestTableEntity);

            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null.\r\nParameter name: record");
        }

        [Fact]
        public async Task delete_async_an_entry_and_the_record_count_should_decrease()
        {
            // Arrange
            await TestDataHelper.SetupRecords(_tableStorage);
            var item = await _tableStorage.GetRecordAsync("Smith", "John");

            // Act
            await _tableStorage.DeleteAsync(item);

            var result = await _tableStorage.GetByPartitionKeyAsync("Smith");

            // Assert
            result.Count().Should().Be(1);
        }
    }
}