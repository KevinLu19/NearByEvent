namespace AzureASPApi.Model;

public class Events
{
	public string EventName { get; set; }
	public string EventDate { get; set; }
	public string EventTime { get; set; }
	public string EventGroup { get; set; }		// This is essentially the synopsis/group of the event.
	public int EventAttendees { get; set; }
}
