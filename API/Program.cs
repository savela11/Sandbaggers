global using API.Models;
using API.Config;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

const string vueAppPolicy = "_vueAppPolicy";

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(vueAppPolicy,
        corsPolicyBuilder => { corsPolicyBuilder.SetIsOriginAllowed((host) => true).AllowAnyHeader().AllowAnyMethod().AllowCredentials(); });
});

builder.ConnectToDatabase();
builder.Services.AddControllers();
builder.Services.ConfigureApiVersioning();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureIdentityOptions();
builder.Services.ConfigureGlobalAuthorizationPolicy();
builder.Services.ConfigureIdentityService();
builder.Services.ConfigureApiAuthorization();

builder.ConfigureJwtAuthentication();

// Configure IService for all Services
builder.Services.AddServices();

// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddSecurityDefinition("token",
        new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer",
            In = ParameterLocation.Header,
            Name = HeaderNames.Authorization
        }
    );
    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "token"
                    },
                },
                Array.Empty<string>()
            }
        }
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  
        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("v1/swagger.json", "My API V1"); });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(vueAppPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.AddControllers();

// app.MapControllers();

app.Run();