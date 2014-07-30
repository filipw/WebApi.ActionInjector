WebApi.ActionInjector
=====================

A small library allowing you to inject dependencies into your action methods directly. Works with any `IDependencyResolver`.

## Registration

	    var config = new HttpConfiguration();
        config.InjectInterfacesIntoActions();

Alternatively, you don't have to register anything - then decorate your injected parameters with `[Inject]` attribute.

## Sample usage:

	public interface IHelloService
	{
	    string SayHello();
	}
	 
	public class HelloService : IHelloService
	{
	    public string SayHello()
	    {
	        return "Hello";
	    }
	}
	 
	public class RequestDto 
	{
	    public string Text {get; set;}
	}
	 
	public class ValuesController : ApiController
	{
	    public string Post(RequestDto input, IHelloService helloService)
	    {
	        return helloService.SayHello() + " " + input.Text;
	    }
	}

[Blog post](http://www.strathweb.com/2014/07/dependency-injection-directly-actions-asp-net-web-api/)