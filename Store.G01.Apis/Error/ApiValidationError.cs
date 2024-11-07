namespace Store.G01.Apis.Error
{
	public class ApiValidationError : ApiErrorResponce
	{
		public IEnumerable<string> Errors { get; set; } = new List<string>();
		public ApiValidationError() : base(400)
		{
		}
	}
}
