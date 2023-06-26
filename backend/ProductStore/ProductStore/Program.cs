using ProductStore.Application.Contracts.Interfaces;
using ProductStore.Application.Implementation.Implementation;
using ProductStore.Repository.Contracts.Interfaces;
using ProductStore.Repository.Implementation.Implementation.Core;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUsuarioRepository, UsuarioImpRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoImpRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoImpRepository>();

builder.Services.AddScoped<IUsuarioApplication, UsuarioImpApplication>();
builder.Services.AddScoped<IProductoApplication, ProductoImpApplication>();
builder.Services.AddScoped<IPedidoApplication, PedidoImpApplication>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
      builder =>
      {
          builder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
