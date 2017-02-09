using System;
using Nancy.Bootstrapper;

namespace Nancy.Raygun.AspNetCore
{
    public class NancyRaygunRegistration : IApplicationStartup
    {
        private static readonly RaygunClient Client;

        static NancyRaygunRegistration()
        {
            var apiKey = RaygunSettings.Settings.ApiKey;


            if (string.IsNullOrWhiteSpace(apiKey)) return;

            Client = new RaygunClient(apiKey);
        }

        public void Initialize(IPipelines pipelines)
        {
            if (Client == null) return;

            var raygunItem = new PipelineItem<Func<NancyContext, Exception, dynamic>>("Raygun", (context, exception) =>
            {
                Client.SendInBackground(context, exception);

                return null;
            });

            pipelines.OnError.AddItemToStartOfPipeline(raygunItem);
        }
    }
}