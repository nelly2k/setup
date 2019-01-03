<Query Kind="Program">
  <Reference>&lt;ProgramFilesX64&gt;\Microsoft SDKs\Azure\.NET SDK\v2.9\bin\plugins\Diagnostics\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var endpoint = "https://test-event-grid-topic.westus2-1.eventgrid.azure.net/api/events";
	var key = "AImjSdlEjZvD9phqJDbPiB/79pvqvNRCYa1MLs90Pto=";

	var client = new HttpClient();
	client.DefaultRequestHeaders.Clear();
	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
	client.DefaultRequestHeaders.Add("aeg-sas-key", key);
	var alarmEvent = new CloudEvent<UserSingUpEvent>();
	alarmEvent.EventId = Guid.NewGuid();
	alarmEvent.EventType = "user.signup";
	alarmEvent.CloudEventsVersion = "1.0";
alarmEvent.Source = "/subscriptions/96421983-e120-4b10-89d0-e4b4e8ed7778/resourceGroups/test-one-app/providers/Microsoft.EventGrid/topics/test-event-grid-topic#/usersignup";
	alarmEvent.EventTypeVersion = "1.0";
	alarmEvent.Data = new UserSingUpEvent();

	alarmEvent.Data.UserEmail = "nelly2k@live.com";

	//	AlarmEvent[] alarmEvents = {alarmEvent};
	Debug.Print("Start posting topic");
	var content = new JsonContent(alarmEvent);
	var result = await client.PostAsync(endpoint, content);
	result.EnsureSuccessStatusCode();

	Debug.Print("Topic is posted with [code:{0}]", result.StatusCode);
	Debug.Print(await result.Content.ReadAsStringAsync());
}


public class CloudEvent<T>
{
	public Guid EventId { get; set; }
	public string EventType { get; set; }
	public string EventTypeVersion { get; set; }
	public string CloudEventsVersion { get; set; }

	public string Source { get; set; } //subject

	public DateTime EventTime { get; set; }
	public string DataVersion { get; set; }
	public T Data { get; set; }
}

public class UserSingUpEvent
{
	public string UserEmail { get; set; }
}

public class JsonContent : StringContent
{
	public JsonContent(object obj) :

	base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/cloudevents+json")
	{ }
}