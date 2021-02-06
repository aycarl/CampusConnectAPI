using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CampusConnectAPI.Models;
using CampusConnectAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CampusConnectAPI.Controllers
{
		[Route("api/[controller]")]
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


		}
}
