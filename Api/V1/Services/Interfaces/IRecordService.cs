using System.Collections.Generic;
using Vue.Apd.Api.V1.Contracts.Requests;
using Vue.Apd.Api.V1.Contracts.Responses;

namespace Vue.Apd.Api.V1.Services.Interfaces
{
	public interface IRecordService
	{
		List<RecordResponse> GetRecords();
		RecordResponse GetRecordById(int recordId);
		RecordResponse UpdateRecord(int recordId, UpdateRecordRequest recordUpdate);
		RecordResponse CreateRecord(CreateRecordRequest recordRequest);
	}
}
