using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadAzure.Server.Controllers
{
	[Route("api/download")]
	[ApiController]
	public class DownloadController : ControllerBase
	{
		private readonly string _azureConnectionString;
		private readonly string _azureContainerName;

		public DownloadController(IConfiguration configuration)
		{
			_azureConnectionString = configuration.GetConnectionString("AzureConnectionString");
			_azureContainerName = "upload-container";
		}

		[HttpGet("{name}")]
		public async Task<IActionResult> Download(string name)
		{
			var container = new BlobContainerClient(_azureConnectionString, _azureContainerName);

			var blob = container.GetBlobClient(name);

			if (await blob.ExistsAsync())
			{
				var a = await blob.DownloadAsync();

				return File(a.Value.Content, a.Value.ContentType, name);
			}

			return BadRequest();
		}
	}
}
