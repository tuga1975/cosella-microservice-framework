﻿using Cosella.Framework.Core;
using Ninject;
using Owin;
using System;

namespace Cosella.Framework.Extensions.Authentication
{
    public static class AuthenticationExtensions
    {
        public static MicroService AddAuthentication(this MicroService microservice)
        {
            microservice.Configuration.Modules.Add(new AuthenticationExtensionsModule());
            microservice.Configuration.Middleware.Add(UseAuthentication);
            return microservice;
        }

        public static MicroService AddAuthentication(this MicroService microservice, Type authenticatorType)
        {
            microservice.Configuration.Modules.Add(new AuthenticationExtensionsModule(authenticatorType));
            microservice.Configuration.Middleware.Add(UseAuthentication);
            return microservice;
        }

        public static IAppBuilder UseAuthentication(IAppBuilder app, IKernel kernel)
        {
            return app.Use<AuthenticationMiddleware>(kernel);
        }
    }
}