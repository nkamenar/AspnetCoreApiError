using System;
using System.Collections.Generic;
using System.Linq;
using Vue.Apd.Api.V1.Contracts.Requests;
using Vue.Apd.Api.V1.Contracts.Responses;
using Vue.Apd.Api.V1.Services.Interfaces;

namespace Vue.Apd.Api.V1.Services
{
	public class RecordService : IRecordService
	{
		private List<Record> _records;

		public RecordService()
		{
			_records = new List<Record>
			{
				new Record
				{
					Id = 1,
					ProjectTitle = "First Project",
					CreatedOn = DateTimeOffset.Now
				},
				new Record
				{
					Id = 2,
					ProjectTitle = "Another Project",
					CreatedOn = DateTimeOffset.Now
				},
				new Record
				{
					Id = 3,
					ProjectTitle = "Third project",
					CreatedOn = DateTimeOffset.Now
				}
			};
		}

		public List<RecordResponse> GetRecords()
		{
			var response = new List<RecordResponse>();
			_records.ForEach(x =>
			{
				response.Add(new RecordResponse
				{
					Id = x.Id,
					ProjectTitle = x.ProjectTitle
				});
			});
			return response;

		}

		public RecordResponse GetRecordById(int recordId)
		{
			var record = _records.SingleOrDefault(x => x.Id == recordId);
			return record == null ? null : new RecordResponse
			{
				Id = record.Id,
				ProjectTitle = record.ProjectTitle
			};
		}

		public RecordResponse UpdateRecord(int recordId, UpdateRecordRequest recordUpdate)
		{
			var exists = GetRecordById(recordId) != null;
			if (!exists)
				return null;
			var index = _records.FindIndex(x => x.Id == recordId);
			_records[index].ProjectTitle = recordUpdate.ProjectTitle;
			var response = new RecordResponse
			{
				Id = _records[index].Id,
				ProjectTitle = _records[index].ProjectTitle
			};
			return response;
		}

		public RecordResponse CreateRecord(CreateRecordRequest recordRequest)
		{
			var record = new Record
			{
				Id = _records.Max(x => x.Id) + 1,
				ProjectTitle = recordRequest.ProjectTitle,
				CreatedOn = DateTimeOffset.Now
			};
			_records.Add(record);
			var response = new RecordResponse
			{
				Id = record.Id,
				ProjectTitle = record.ProjectTitle
			};
			return response;
		}
	}
}
