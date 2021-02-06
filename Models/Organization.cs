﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CampusConnectAPI.Models
{
		public class Organization
		{
				[BsonId]
				[BsonRepresentation(BsonType.ObjectId)]
				public string Id { get; set; }

				[BsonElement("Name")]
				public string Name { get; set; }

				[BsonElement("Description")]
				public string Description { get; set; }
		}
}
