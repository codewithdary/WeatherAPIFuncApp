using System;
using Azure;
using Azure.Data.Tables;

namespace WeatherAPI.Logic
{
    public class ImageProcessEntity : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    // Your additional properties
    public string Status { get; set; }
    // Add other properties as needed

    public ImageProcessEntity()
    {
        // Default constructor is required for deserialization
    }
}

}