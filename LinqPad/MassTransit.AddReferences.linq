<Query Kind="Program">
  <NuGetReference>Faker</NuGetReference>
  <NuGetReference>MassTransit</NuGetReference>
  <NuGetReference>MassTransit.RabbitMQ</NuGetReference>
  <NuGetReference>NBuilder</NuGetReference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Faker</Namespace>
  <Namespace>FizzWare.NBuilder</Namespace>
  <Namespace>MassTransit</Namespace>
  <Namespace>MassTransit.RabbitMqTransport</Namespace>
  <Namespace>MassTransit.RabbitMqTransport.Configurators</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

async Task Main()
{
	var messageBus = MassTransit.BusFactoryConfiguratorExtensions.CreateUsingRabbitMq(MassTransit.Bus.Factory, cfg =>
	{
				var host = cfg.Host(new Uri("rabbitmq://dev-admin.corp.livehire.com"), h =>
					   {
						   h.Username("livehire_dev");
						   h.Password("hU93Pj90QvEDV31sRJa1");
					   });
	});
	
	messageBus.Start();
	
	var name = new Tuple<string, string>(Faker.NameFaker.FirstName(), Faker.NameFaker.LastName());
	
	var command =Builder<ReferenceCheck.Commands.CreateReferenceCheckCommand>.CreateNew()
		.With(x=>x.JobCandidate = Builder<ReferenceCheck.Commands.CreateReferenceCheckCommand.JobCandidateModel>.CreateNew().Build())
		.Build();
    Debug.Print( JsonConvert.SerializeObject(command));
	await messageBus.Publish(command);
	messageBus.Stop();
}
}
namespace ReferenceCheck.Commands{
public class CreateReferenceCheckCommand
{
	public JobCandidateModel JobCandidate { get; set; } = new JobCandidateModel();
	public int CompanyId { get; set; }
	public string Division { get; set; }
	public string JobTitle { get; set; }
	public string ProviderCode { get; set; }
	public string RequestedBy { get; set; }

	public Guid? TemplateId { get; set; }
	public Guid? WorkflowId { get; set; }
	public Guid RequestId { get; set; } = Guid.NewGuid();

	public class JobCandidateModel
	{
		public Guid CandidateId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public PhoneNumber MobilePhoneNumber { get; set; } = new PhoneNumber();
	}

	public class PhoneNumber
	{
		public string Number { get; set; }
		public string CountryCode { get; set; }
	}
}