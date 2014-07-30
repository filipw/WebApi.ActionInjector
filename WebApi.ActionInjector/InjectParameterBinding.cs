using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace WebApi.ActionInjector
{
    public class InjectParameterBinding : HttpParameterBinding
    {
        public InjectParameterBinding(HttpParameterDescriptor descriptor)
            : base(descriptor)
        {
        }

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            if (actionContext.ControllerContext.Configuration.DependencyResolver != null)
            {
                var resolved = actionContext.ControllerContext.Configuration.DependencyResolver.GetService(Descriptor.ParameterType);
                actionContext.ActionArguments[Descriptor.ParameterName] = resolved;
            }
            return Task.FromResult(0);
        }
    }
}