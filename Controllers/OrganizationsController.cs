using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CampusConnectAPI.Models;
using CampusConnectAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectAPI.Controllers
{
		[Route("[controller]")]
		[ApiController]
		public class OrganizationsController: ControllerBase
		{
				private readonly OrganizationsService _organizationsService;

				public OrganizationsController(OrganizationsService organizationsService)
				{
						_organizationsService = organizationsService;
				}

				
				[HttpGet]
				public ActionResult<List<Organization>> Get() =>
						_organizationsService.Get();

				[HttpGet("{id:length(24)}", Name = "GetOrganization")]
				public ActionResult<Organization> Get(string id)
				{
						var organization = _organizationsService.Get(id);

						if (organization == null)
						{
								return NotFound();
						}

						return organization;
				}

				[HttpPost]
				public ActionResult<Organization> Create(Organization organization)
				{
						_organizationsService.Create(organization);

						return CreatedAtRoute("GetOrganization", new { id = organization.Id.ToString(), organization });
				}

				[HttpPut("{id:length(24)}")]
				public IActionResult Update(string id, Organization organizationIn)
				{
						var organization = _organizationsService.Get(id);

						if(organization == null)
						{
								return NotFound();
						}

						_organizationsService.Update(id, organizationIn);

						return NoContent();
				}

				[HttpDelete("{id:length(24)}")]
				public IActionResult Delete(string id)
				{
						var organization = _organizationsService.Get(id);

						if (organization == null)
						{
								return NotFound();
						}

						_organizationsService.Remove(id);

						return NoContent();
				}

		}
}
