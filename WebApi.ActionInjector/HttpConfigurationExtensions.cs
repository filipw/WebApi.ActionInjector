using System.Web.Http;

namespace WebApi.ActionInjector
{
    public static class HttpConfigurationExtensions
    {
        public static void InjectInterfacesIntoActions(this HttpConfiguration config)
        {
            config.ParameterBindingRules.Insert(0, param =>
            {
                if (param.ParameterType.IsInterface)
                {
                    return new InjectParameterBinding(param);
                }

                return null;
            });
        }
    }
}