
[![Build Status](https://travis-ci.org/six2six/fixture-factory.png?branch=master)](https://travis-ci.org/zamabraga/NFixture-Factory)
# fixture-factory-dot-net
 https://github.com/six2six/fixture-factory
 
Fixture Factory .NET is a tool to help developers quickly build and organize fake objects for unit tests. The key idea is to create specification limits of the data (templates) instead of hardcoded data. Try using N-F-F, then you can focus on the behavior of your methods and we manage the data.
Initially ported from [fixture-factory](https://github.com/six2six/fixture-factory)  

## Usage

Writing template rules

	Fixture.Of<Client>().AddTemplate("valid", 
				new Rule()
					.Add("Name", "Jorg Ancrath")
					.Add("Address", Rule.One<Address>("Valid Address"))					
				    .Add("CPF", Rule.Cpf())
	);

	Fixture.Of<Address>().AddTemplate ("Valid Address", 
				new Rule ()
				.Add("Street", "Castelo")
				.Add("City", "Cidade Alta")
				.Add("State", "Terras Altas de Rennar")
				.Add("Country", "Ancrath")
				
			);

Using on your tests code:

Gimme one object from label "valid"

	Client client = Fixture.From<Client>().Gimme(valid);

Gimme N objects from label "valid"

	List<Client> clients = Fixture.From<Client>().Gimme(5, valid);


### Managing Templates

Templates can be written within TemplateLoader interface

	public class ClientTemplateLoader implements TemplateLoader {
	    @Override
	    public void load() {
	        Fixture.Of<Client>().AddTemplate("valid", 
				new Rule()
					.Add("Name", "Jorg Ancrath")
					.Add("Address", Rule.One<Address>("Valid Address"))					
				    .Add("CPF", Rule.Cpf())
			);

			Fixture.Of<Address>().AddTemplate ("Valid Address", 
				new Rule ()
				.Add("Street", "Castelo")
				.Add("City", "Cidade Alta")
				.Add("State", "Terras Altas de Rennar")
				.Add("Country", "Ancrath")
				
			);
	    }
	}

All templates can be loaded using FixtureFactoryLoader

	FixtureFactoryLoader.LoadTemplates();


Example of loading templates with NUnit tests

	[TestFixtureSetUp()]
	public void SetUp()
	{
		FixtureFactoryLoader.LoadTemplates();
	}

## License

Fixture-Factory is released under the Apache 2.0 license. See the LICENSE file included with the distribution for details.

