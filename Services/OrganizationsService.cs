using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using CampusConnectAPI.Models;

namespace CampusConnectAPI.Services
{
		public class OrganizationsService
		{
				private readonly IMongoCollection<Organization> _organizations;

				public OrganizationsService(ICampusConnectDatabaseSettings settings)
				{
						var client = new MongoClient(settings.ConnectionString);
						var database = client.GetDatabase(settings.DatabaseName);

						_organizations = database.GetCollection<Organization>(settings.OrganizationsCollectionName);
				}

				public List<Organization> Get() =>
						_organizations.Find(organization => true).ToList();

    public Organization Get(string id) =>
        _organizations.Find<Organization>(organization => organization.Id == id).FirstOrDefault();

    public Organization Create(Organization organization)
    {
      _organizations.InsertOne(organization);
      return organization;
    }

    public void Update(string id, Organization organizationIn) =>
        _organizations.ReplaceOne(organization => organization.Id == id, organizationIn);

    public void Remove(Organization organizationIn) =>
        _organizations.DeleteOne(organization => organization.Id == organizationIn.Id);

    public void Remove(string id) =>
        _organizations.DeleteOne(organization => organization.Id == id);
  }
}
