using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadAzure.Server
{
	public class BlobDto
	{
		public string Name { get; set; }
		public string Uri { get; set; }
		public string ContentType { get; set; }
	}
}
