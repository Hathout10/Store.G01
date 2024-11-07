namespace Store.G01.Apis.Error
{
	public class ApiExceptionResponse : ApiErrorResponce
	{
		public string? Details { get; set; }
		public ApiExceptionResponse(int statusCode, string? message = null, string? details = null)
			: base(statusCode, message)
		{
			Details = details;
		}
	}
}