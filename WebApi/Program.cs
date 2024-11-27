using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

//Inyeccion de dependencias
builder.Services.AddTransient<IUsuarioServices, UsuarioServices>();
builder.Services.AddTransient<IActividadesServices, ActividadesServices>();
builder.Services.AddTransient<IAgenciasServices, AgenciasServices>();
builder.Services.AddTransient<IClienteServices, ClienteServices>();
builder.Services.AddTransient<IReservacionesServices, ReservacionesServices>();
builder.Services.AddTransient<IDisponibilidadActividadesServices, DisponibilidadActividadesServices>();
builder.Services.AddTransient<IImagenesActividadesServices, ImagenesActividadesServices>();
builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<ICorreoServices, CorreoServices>();
builder.Services.AddTransient<IDashboardServices, DashboardServices>();




builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
);
var app = builder.Build();
app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
