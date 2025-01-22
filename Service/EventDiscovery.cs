using HtmlAgilityPack;

namespace AzureASPApi.Service;

public class EventDiscovery
{
	private static readonly string _BASEURL = "https://www.meetup.com";

	public string _city_name;
	public string _state_code;
	public string _country_name;

	public EventDiscovery(string city_name, string state, string country_name)
	{
		_city_name = city_name;
		_state_code = state;
		_country_name = country_name;
	}

	public string NavigateArea()
	{
		var complete_url = $"{_BASEURL}/find/?location={_country_name}--{_state_code}--{_city_name}&source=EVENTS";

		// Load web
		try
		{
			var web = new HtmlWeb();

			var document = web.Load(complete_url);

			if (document.Text != null)
				return document.Text;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		return String.Empty;
	}

	public void Discovery()
	{
		string chk_web_result = NavigateArea();

		if (chk_web_result != String.Empty)
		{
			Console.WriteLine(chk_web_result);
		}
	}
}
