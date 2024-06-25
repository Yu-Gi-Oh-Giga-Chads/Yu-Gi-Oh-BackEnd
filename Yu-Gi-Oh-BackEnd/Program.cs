using BusinessLayer;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Cors;
using System.Globalization;

namespace Yu_Gi_Oh_BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var MyAllowSpecificOrigins = "AllowAll";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins); 

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
