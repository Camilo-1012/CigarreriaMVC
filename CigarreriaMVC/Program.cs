using CigarreriaMVC.AccesoDatos.Data;
using CigarreriaMVC.AccesoDatos.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews ( );

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ApplicationDbContext> ( options =>
    options.UseSqlServer ( connectionString ) );

builder.Services.AddScoped<IContenedorTrabajo , ContenedorTrabajo> ( );

var app = builder.Build();

// resto igual...
