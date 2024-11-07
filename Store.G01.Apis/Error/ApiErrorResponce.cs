namespace Store.G01.Apis.Error
{
	public class ApiErrorResponce
	{
		public int StatusCode { get; set; }
		public string Message { get; set; }

		public ApiErrorResponce(int statusCode, string? message = null)
		{
			StatusCode = statusCode;
			Message = message ?? GetDefaultMessageForStatysCode(statusCode);
		}

		private string GetDefaultMessageForStatysCode(int statusCode)
		{
			var message = statusCode switch
			{
				400 => "a bad request, you have made",
				401 => "Authorized, you r not",
				404 => "Resource was not found",
				500 => "server Error",
				_ => null



			};


			return message;
		}

	}
}