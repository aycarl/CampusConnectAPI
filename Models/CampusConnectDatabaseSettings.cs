using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusConnectAPI.Models
{
		public class CampusConnectDatabaseSettings : ICampusConnectDatabaseSettings
		{
				public string OrganizationsCollectionName { get; set; }
				public string ConnectionString { get; set; }
				public string DatabaseName { get; set; }
		}

		public interface ICampusConnectDatabaseSettings
		{
				public string OrganizationsCollectionName { get; set; }
				public string ConnectionString { get; set; }
				public string DatabaseName { get; set; }
		}
}
