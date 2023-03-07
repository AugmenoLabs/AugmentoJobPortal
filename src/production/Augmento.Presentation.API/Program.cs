using Agumento.Core.Application;
using Augmento.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Augmento.Presentation.API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter your JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
                Array.Empty<string>()
            }
        });
});

builder.Services.AddAuthentication(options =>
{
options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
o.Authority = "http://localhost:8080/realms/MyRealm/";
o.Audience = "MyClient";

o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
{
    ValidAudiences = new string[] { "master-realm", "account", "MyClient" }
};
o.Events = new JwtBearerEvents()
{
    OnAuthenticationFailed = c =>
    {
        c.NoResult();
        c.Response.StatusCode = 500;
        c.Response.ContentType = "text/plain";
        return c.Response.WriteAsync(c.Exception.ToString());
    }
};

    o.RequireHttpsMetadata = false;
    o.SaveToken = true;
    o.Validate();
});

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("HR", policy => policy.RequireClaim("HR", "[HR]"));
    o.AddPolicy("interviewr", policy => policy.RequireRole("[interviewr]"));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthentication();
//app.UseAuthorization();
app.UseAuthorization();
app.MapControllers();

app.Run();
