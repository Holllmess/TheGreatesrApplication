using TheGreatesrApplication.Services.Repository;
using TheGreatesrApplication.Services;
using TheGreatesrApplication.DataBasesServices;

namespace TheGreatesrApplication
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

            builder.Services.AddScoped<IAKindRepository, AKindRepository>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddScoped<IAKindRepository, AKindRepository>();
            builder.Services.AddScoped<IASkillRepository, ASkillRepository>();

            DataBaseSQL.host = builder.Configuration["MYSQL_DBHOST"] ?? builder.Configuration.GetConnectionString("MYSQL_DBHOST");
            DataBaseSQL.port = builder.Configuration["MYSQL_DBPORT"] ?? builder.Configuration.GetConnectionString("MYSQL_DBPORT");
            DataBaseSQL.password = builder.Configuration["MYSQL_PASSWORD"] ?? builder.Configuration.GetConnectionString("MYSQL_PASSWORD");
            DataBaseSQL.userid = builder.Configuration["MYSQL_USER"] ?? builder.Configuration.GetConnectionString("MYSQL_USER");
            DataBaseSQL.database = builder.Configuration["MYSQL_DATABASE"] ?? builder.Configuration.GetConnectionString("MYSQL_DATABASE");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}