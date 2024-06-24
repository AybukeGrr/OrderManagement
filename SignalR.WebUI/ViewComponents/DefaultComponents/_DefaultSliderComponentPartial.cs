using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WebUI.Dtos.SliderDtos;


namespace SignalR.WebUI.ViewComponents.DefaultComponents
{
	public class _DefaultSliderComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7295/api/Slider");

			if (!responseMessage.IsSuccessStatusCode)
			{
				// Handle error response with detailed message
				var statusCode = responseMessage.StatusCode;
				var responseBody = await responseMessage.Content.ReadAsStringAsync();
				throw new Exception($"Error fetching data from API. Status code: {statusCode}, Response: {responseBody}");
			}

			var jsonData = await responseMessage.Content.ReadAsStringAsync();

			try
			{
				var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
				return View(values);
			}
			catch (JsonReaderException ex)
			{
				// Log the error and handle the invalid JSON format
				throw new Exception($"JsonReaderException: {ex.Message}");
			}
		}
	}


}
