using Application.DTOs.Request;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Models;
using Infra.Data.Context;
using Infra.Data.Repository;
using Infra.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Service.Services;
using Service.Services.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "ClientManagementAPI", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    opt.IncludeXmlComments(xmlPath);
});
builder.Services.AddDbContext<ClientDbContext>(options => 

options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection")));

//Injeção de Dependência PessoaFísica
builder.Services.AddScoped<IBaseRepository<ClientePessoaFisica>, BaseRepository<ClientePessoaFisica>>();
builder.Services.AddScoped<IBaseService<ClientePessoaFisica>, BaseService<ClientePessoaFisica>>();
builder.Services.AddScoped<IClientePessoaFisicaRepository, ClientePessoaFisicaRepository>();
builder.Services.AddScoped<IClientePessoaFisicaServices, ClientePessoaFisicaServices>();

//Injeção de Dependência PessoaJuridica
builder.Services.AddScoped<IBaseRepository<ClientePessoaJuridica>, BaseRepository<ClientePessoaJuridica>>();
builder.Services.AddScoped<IBaseService<ClientePessoaJuridica>, BaseService<ClientePessoaJuridica>>();
builder.Services.AddScoped<IClientePessoaJuridicaRepository, ClientePessoaJuridicaRepository>();
builder.Services.AddScoped<IClientePessoaJuridicaServices, ClientePessoaJuridicaServices>();

//Injeção de Dependência Endereço
builder.Services.AddScoped<IBaseRepository<Endereco>, BaseRepository<Endereco>>();
builder.Services.AddScoped<IBaseService<Endereco>, BaseService<Endereco>>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IEnderecoServices, EnderecoServices>();

builder.Services.AddSingleton(new MapperConfiguration(config =>
{
    config.CreateMap<ClientePessoaFisicaRequestDTO, ClientePessoaFisica>();
    config.CreateMap<ClientePessoaFisica, ClientePessoaFisicaGetResponseDTO>();
    config.CreateMap<ClientePessoaFisica, ClientePessoaFisicaGetByIdResponseDTO>();
    config.CreateMap<ClientePessoaFisica, IdResponseDTO>();

    config.CreateMap<ClientePessoaJuridicaRequestDTO, ClientePessoaJuridica>();
    config.CreateMap<ClientePessoaJuridica, ClientePessoaJuridicaGetResponseDTO>();
    config.CreateMap<ClientePessoaJuridica, ClientePessoaJuridicaGetByIdResponseDTO>();
    config.CreateMap<ClientePessoaJuridica, IdResponseDTO>();

    config.CreateMap<EnderecoRequestDTO, Endereco>();
    config.CreateMap<Endereco, EnderecoGetResponseDTO>();
    config.CreateMap<Endereco, EnderecoGetByIdResponseDTO>();
    config.CreateMap<Endereco, IdResponseDTO>();
}).CreateMapper());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
