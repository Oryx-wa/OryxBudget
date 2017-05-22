using Autofac.Builder;
using Autofac.Features.Scanning;
using Microsoft.AspNetCore.SignalR.Hubs;
using System;
using System.Reflection;

namespace Autofac.Signalr
{

    public static class AutoFacExtensions
    {

        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle>
        RegisterHubs(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            return builder.RegisterAssemblyTypes(assemblies)
            .Where(t => typeof(IHub).IsAssignableFrom(t))
            .ExternallyOwned();
        }
    }
}
