using System;

namespace _247Pro.Model.Services.EnvironmentService
{
    public class EnvironmentService : IEnvironmentService
    {
        public EnvironmentService()
        {
            EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
        }
        public string EnvironmentName { get; set; }
    }
}
