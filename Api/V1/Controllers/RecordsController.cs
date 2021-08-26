using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vue.Apd.Api.V1.Contracts;
using Vue.Apd.Api.V1.Contracts.Requests;
using Vue.Apd.Api.V1.Contracts.Responses;
using Vue.Apd.Api.V1.Services.Interfaces;

namespace Vue.Apd.Api.V1.Controllers
{
	[ApiController]
	[ApiVersion(ApiRoutes.ApiVersion, Deprecated = ApiRoutes.IsDeprecated)]
	public class RecordsController : ControllerBase
	{
		private readonly IRecordService _recordService;
		private string ApiBaseUrl => $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}/";

		public RecordsController(IRecordService recordService)
		{
			_recordService = recordService;
		}

		[HttpGet(ApiRoutes.Records.GetAll)]
		public IActionResult GetAll()
		{
			return Ok(_recordService.GetRecords());
		}

		[HttpGet(ApiRoutes.Records.Get)]
		public IActionResult Get(int recordId)
		{
			var record = _recordService.GetRecordById(recordId);
			if (record == null)
				return NotFound();

			return Ok(record);
		}

		[HttpPost(ApiRoutes.Records.Create)]
		public IActionResult Create([FromBody] CreateRecordRequest recordRequest)
		{
			var response = _recordService.CreateRecord(recordRequest);

			var location = ApiBaseUrl + ApiRoutes.Records.Get.Replace("{recordId}", response.Id.ToString());
			return Created(location, response);
		}

		[HttpPut(ApiRoutes.Records.Update)]
		public IActionResult Update([FromRoute] int recordId, [FromBody] UpdateRecordRequest request)
		{
			var updated = _recordService.UpdateRecord(recordId, request);
			if (updated == null)
				return NotFound();
			return Ok(updated);

		}
	}
}
