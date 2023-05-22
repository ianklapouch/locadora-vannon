using LocadoraVannon.Models;
using LocadoraVannon.Repositories;
using LocadoraVannon.Repositories.Interfaces;
using LocadoraVannon.Services;
using LocadoraVannon.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao container.
builder.Services.AddControllersWithViews();

// Configurar a injeção de dependência para o contexto do banco de dados
string connectionString = builder.Configuration.GetConnectionString("SqlServer")!;
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IFilmeService, FilmeService>();

builder.Services.AddScoped<ILocacaoRepository, LocacaoRepository>();
builder.Services.AddScoped<ILocacaoService, LocacaoService>();

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Login/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();