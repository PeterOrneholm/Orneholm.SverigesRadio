using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orneholm.SverigesRadio.Api;
using Orneholm.SverigesRadio.Api.Models.Request.Common;
using Orneholm.SverigesRadio.BlazorSample.Services;

namespace Orneholm.SverigesRadio.BlazorSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<SharedAudioPlayer>();

            services.AddHttpClient(nameof(SverigesRadioApiClient), httpClient =>
            {
                httpClient.BaseAddress = SverigesRadioApiDefaults.ProductionApiBaseUrl;
            });

            services.AddTransient<ISverigesRadioApiClient>(s =>
            {
                var httpClient = s.GetRequiredService<IHttpClientFactory>().CreateClient(nameof(SverigesRadioApiClient));

                return new SverigesRadioApiClient(httpClient, new AudioSettings
                {
                    AudioQuality = AudioQuality.Normal,
                    LiveAudioTemplateId = SverigesRadioApiIds.LiveAudioTemplates.HLS,
                    OnDemandAudioTemplateId = SverigesRadioApiIds.OnDemandAudioTemplates.Html5_Desktop
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
