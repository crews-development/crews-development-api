namespace CrewsDevelopment.Api.Models;

public class TimestampModel
{
	public Int64 Unix { get; }
	public string Utc => getUtc();

	public TimestampModel() : this(DateTime.Now) { }

	public TimestampModel(DateTime dateTime) : this(
		new DateTimeOffset(dateTime.ToUniversalTime()))
	{ }

	public TimestampModel(DateTimeOffset offset)
		=> Unix = (Int64)offset.ToUnixTimeMilliseconds();

	public TimestampModel(Int64 milliseconds) => Unix = milliseconds;

	private string getUtc()
	{
		DateTime epoch = new(1970, 1, 1);
		DateTime dateTime = epoch.AddMilliseconds(Unix);
		return dateTime.ToString("r");
	}
}

public record TimestampError
{
	public string Error => "Invalid Date";
}