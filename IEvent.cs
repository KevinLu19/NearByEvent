namespace AzureASPApi;

public interface IEvent
{
	List<string> GetLocalEvent();		// Will contain information for 1 event such as title, description, etc.
}
