using System.Net;
using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

public static async Task<IActionResult> Run(HttpRequest req)
{
    string connectionString = Environment.GetEnvironmentVariable("StorageConnectionString");
    BlobServiceClient serviceClient = new BlobServiceClient(connectionString);
    BlobContainerClient containerClient = serviceClient.GetBlobContainerClient("drop");
    BlobClient blobClient = containerClient.GetBlobClient("records.json");
    var response = await blobClient.DownloadAsync();
    return new FileStreamResult(response?.Value?.Content, response?.Value?.ContentType);
}