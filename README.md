
[![Build Status](https://travis-ci.org/six2six/fixture-factory.png?branch=master)](https://travis-ci.org/zamabraga/NFixture-Factory)
# NFixture-Factory

NFixture Factory  is a tool to help developers quickly build and organize fake objects for unit tests. The key idea is to create specification limits of the data (templates) instead of hardcoded data. Try using N-F-F, then you can focus on the behavior of your methods and we manage the data.
Initially ported from [fixture-factory](https://github.com/six2six/fixture-factory)  

## NuGet Packages

To install NFixture Factory with NuGet, run the following command in the Package Manager Console: 

	Install-Package NFixtureFactory

## Usage

Writing template rules

	NFixture.Of<Client>().AddTemplate("valid", 
				new Rule()
					.Add("Name", "Jorg Ancrath")
					.Add("Address", Rule.One<Address>("Valid Address"))					
				    .Add("CPF", Rule.Cpf())
	);

	NFixture.Of<Address>().AddTemplate ("Valid Address", 
				new Rule ()
				.Add("Street", "Castelo")
				.Add("City", "Cidade Alta")
				.Add("State", "Terras Altas de Rennar")
				.Add("Country", "Ancrath")
				
			);

or

	NFixture.Of<Client>().AddTemplate("valid") 
				.ForMember(e => e.Name, "Jorg Ancrath")
				.ForMember(e => e.Address, Rule.One<Address>("Valid Address"))					
				.ForMember(e => e.CPF, Rule.Cpf());

	NFixture.Of<Address>().AddTemplate ("Valid Address")
				.ForMember(e => e.Street, "Castelo")
				.ForMember(e => e.City, "Cidade Alta")
				.ForMember(e => e.State, "Terras Altas de Rennar")
				.ForMember(e => e.Country, "Ancrath");	

Using on your tests code:

Gimme one object from label "valid"

	Client client = NFixture.From<Client>().Gimme("valid");

Gimme N objects from label "valid"

	List<Client> clients = NFixture.From<Client>().Gimme(5, "valid");


### Managing Templates

Templates can be written within TemplateLoader interface

	public class ClientTemplate : ITemplateLoader {
	   
	    public void Load() {
	        NFixture.Of<Client>().AddTemplate("valid", 
				new Rule()
					.Add("Name", "Jorg Ancrath")
					.Add("Address", Rule.One<Address>("Valid Address"))					
				    .Add("CPF", Rule.Cpf())
			);

			NFixture.Of<Address>().AddTemplate ("Valid Address", 
				new Rule ()
				.Add("Street", "Castelo")
				.Add("City", "Cidade Alta")
				.Add("State", "Terras Altas de Rennar")
				.Add("Country", "Ancrath")
				
			);
	    }
	}

or

	public class ClientTemplate : ITemplateLoader {
	   
	    public void Load() {
	        NFixture.Of<Client>().AddTemplate("valid") 
				.ForMember(e => e.Name, "Jorg Ancrath")
				.ForMember(e => e.Address, Rule.One<Address>("Valid Address"))					
				.ForMember(e => e.CPF, Rule.Cpf());

			NFixture.Of<Address>().AddTemplate ("Valid Address")
				.ForMember(e => e.Street, "Castelo")
				.ForMember(e => e.City, "Cidade Alta")
				.ForMember(e => e.State, "Terras Altas de Rennar")
				.ForMember(e => e.Country, "Ancrath");	
	    }
	}

All templates can be loaded using FixtureFactoryLoader

	NFixtureFactoryLoader.LoadTemplates();


Example of loading templates with NUnit tests

	[TestFixtureSetUp()]
	public void SetUp()
	{
		NFixtureFactoryLoader.LoadTemplates();
	}

## License

NFixture-Factory is released under the Apache 2.0 license. See the LICENSE file included with the distribution for details.

