
using password_manager_api.Repositories.PasswordRepository;
using password_manager_api.Repositories.UserRepository;
using password_manager_api.Utilities;

namespace password_manager_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var services = builder.Services;


            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
            services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            services.AddCors(options => options.AddPolicy(
                name: "AllowOrigin",
                policy =>
                {
                    policy.WithOrigins("http://localhost:5192", "https://localhost:7293").AllowAnyHeader().AllowAnyMethod();
                }
                
                ));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordRepository, PasswordRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowOrigin");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}