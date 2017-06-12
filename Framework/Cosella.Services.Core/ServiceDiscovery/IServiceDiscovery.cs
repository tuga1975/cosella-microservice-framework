﻿using Cosella.Services.Core.ApiClient;
using System.Threading.Tasks;

namespace Cosella.Services.Core.ServiceDiscovery
{
    public interface IServiceDiscovery
    {
        IServiceRegistration RegisterService();

        IServiceRegistration RegisterService(Task<ApiClientResponse<string>> registrationTask);

        Task<ApiClientResponse<string>> RegisterServiceDeferred();

        void DeregisterService(IServiceRegistration registration);

        Task<IServiceInstanceInfo> FindServiceByName(string serviceName);

        Task<IServiceInfo[]> ListServices();
    }
}