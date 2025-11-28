using CigarreriaMVC.AccesoDatos.Data;
using CigarreriaMVC.AccesoDatos.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Puedes dejar esto si quieres forzar el puerto:
builder.WebHost.UseUrls ( "http://localhost:5130" );

// MVC
builder.Services.AddControllersWithViews ( );

// Cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection'.");

// DbContext
builder.Services.AddDbContext<ApplicationDbContext> ( options =>
    options.UseSqlServer ( connectionString ) );

// Repositorios
builder.Services.AddScoped<IContenedorTrabajo , ContenedorTrabajo> ( );

var app = builder.Build();

// Middleware estándar
if ( !app.Environment.IsDevelopment ( ) )
    {
    app.UseExceptionHandler ( "/Home/Error" );
    app.UseHsts ( );
    }

app.UseHttpsRedirection ( );
app.UseStaticFiles ( );

app.UseRouting ( );

app.UseAuthentication ( );
app.UseAuthorization ( );

// 🔹 1. Rutas para ÁREAS (Admin, etc.)
app.MapControllerRoute (
    name: "areas" ,
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}" );

app.MapControllerRoute (
    name: "default" ,
    pattern: "{controller=Home}/{action=Index}/{id?}" );


app.Run ( );
