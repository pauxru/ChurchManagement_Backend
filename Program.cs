using Churchmanagement.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer; // Add this for JWT Bearer authentication
using Auth0.AspNetCore.Authentication;

namespace Churchmanagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));

            builder.Services.AddScoped<IMemberService, MemberService>();
            builder.Services.AddScoped<IChurchService, ChurchService>();
            builder.Services.AddScoped<IClergyServices, ClergyServices>();
            builder.Services.AddScoped<IBoardService, BoardService>();
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<ITwilioCommunication, TwilioCommunication>();
            builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:3000", "https://localhost:3000", "https://www.pawadtech.com")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                });
            });

            // Add JWT Bearer authentication for API
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}"; // Auth0 domain
                options.Audience = builder.Configuration["Auth0:Audience"]; // API Identifier
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine("Authentication failed: " + context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token validated: " + context.SecurityToken);
                        return Task.CompletedTask;
                    }
                };
            });

            // Add Auth0 configuration for web app authentication (optional)
            //builder.Services.AddAuth0WebAppAuthentication(options =>
            //{
            //    options.Domain = builder.Configuration["Auth0:Domain"];
            //    options.ClientId = builder.Configuration["Auth0:ClientId"];
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();
            app.UseCors("AllowFrontend");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}