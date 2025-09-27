using Microsoft.EntityFrameworkCore;
using TestGraph.Data;
using TestGraph.GraphQL.Mutations;
using TestGraph.GraphQL.Queries;
using TestGraph.UseCases.Appointment.Commands.Book;
using TestGraph.UseCases.Appointment.Commands.Cancel;
using TestGraph.UseCases.Appointment.Queries.GetAll;
using TestGraph.UseCases.Appointment.Queries.GetAllByDoctorId;
using TestGraph.UseCases.Appointment.Queries.GetAllByPersonId;
using TestGraph.UseCases.Appointment.Queries.GetById;
using TestGraph.UseCases.Doctor.Commands.Create;
using TestGraph.UseCases.Doctor.Commands.Delete;
using TestGraph.UseCases.Doctor.Queries.Get;
using TestGraph.UseCases.Doctor.Queries.GetAll;
using TestGraph.UseCases.Person.Commands.Create;
using TestGraph.UseCases.Person.Commands.Delete;
using TestGraph.UseCases.Person.Queries.GetAll;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CreatePersonHandler>();
builder.Services.AddScoped<DeletePersonHandler>();
builder.Services.AddScoped<CreateDoctorHandler>();
builder.Services.AddScoped<DeleteDoctorHandler>();
builder.Services.AddScoped<BookAppointmentHandler>();
builder.Services.AddScoped<CancelAppointmentHandler>();

builder.Services.AddScoped<GetPersonByIdHandler>();
builder.Services.AddScoped<GetAllPersonHandler>();
builder.Services.AddScoped<GetDoctorByIdHandler>(); 
builder.Services.AddScoped<GetAllDoctorHandler>();
builder.Services.AddScoped<GetAppointmentByIdHandler>();
builder.Services.AddScoped<GetAllAppointmentHandler>();
builder.Services.AddScoped<GetAllAppointmentByDoctorIdHandler>();
builder.Services.AddScoped<GetAllAppointmentByPersonIdHandler>();
builder.Services.AddScoped<DoctorMutation>();
builder.Services.AddScoped<PersonMutation>();
builder.Services.AddScoped<AppointmentMutation>();
builder.Services.AddScoped<PersonQueries>();
builder.Services.AddScoped<DoctorQueries>();
builder.Services.AddScoped<AppointmentQueries>();

builder.Services.AddGraphQLServer()
    .AddMutationType<GraphQLRootMutation>()
    .AddQueryType<GraphQLRootQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapGraphQL();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
