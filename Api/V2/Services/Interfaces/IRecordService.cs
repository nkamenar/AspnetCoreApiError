using System.Collections.Generic;
using Vue.Apd.Api.V2.Contracts.Requests;
using Vue.Apd.Api.V2.Contracts.Responses;

namespace Vue.Apd.Api.V2.Services.Interfaces
{
	public interface IRecordService
	{
		List<RecordResponse> GetRecords();
		RecordResponse GetRecordById(int recordId);
		RecordResponse UpdateRecord(int recordId, UpdateRecordRequest recordUpdate);
		RecordResponse CreateRecord(CreateRecordRequest recordRequest);
	}
}
