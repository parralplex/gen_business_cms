using business_hierarchy_cms.Services;
using business_hierarchy_cms.Services.Abstract;
using DomainModel.DTO;
using DomainModel.Model.Context;
using Infrastructure;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICRUDService<BusinessDTO>, BusinessUnitService>();
builder.Services.AddTransient<ICRUDService<DivisionDTO>, DivisionService>();
builder.Services.AddTransient<ICRUDService<DepartmentDTO>, DepartmentService>();
builder.Services.AddTransient<ICRUDService<ProjectDTO>, ProjectService>();
builder.Services.AddTransient<ICRUDService<EmployeeDTO>, EmployeeService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkManager>();

builder.Services.AddGraphQLServer().AddQueryType<GraphQLQuery>();

builder.Services.AddDbContext<BusinessModelContext>(options => options.UseSqlServer(builder.Configuration["Data:DefaultConnection:ConnectionString"]));

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

app.MapGraphQL("/graphql");

app.Run();
