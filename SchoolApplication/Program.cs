using Microsoft.EntityFrameworkCore;
using SchoolApplication.src.Data;
using SchoolApplication.src.Interfaces;
using SchoolApplication.src.Repositories.CourseRepo;
using SchoolApplication.src.Repositories.SchoolRepo;
using SchoolApplication.src.Repositories.StudentRepo;
using SchoolApplication.src.Services.CourseAppService;
using SchoolApplication.src.Services.SchoolAppService;
using SchoolApplication.src.Services.StudentAppService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//inject services
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<IStudentAppService, StudentAppService>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();
builder.Services.AddScoped<ICourseAppService, CourseAppService>();
builder.Services.AddScoped<ISchoolAppService, SchoolAppService>();
builder.Services.AddScoped<ISchoolRepo, SchoolRepo>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

//Add DbContext
const string connectionString = "Server=(localdb)\\Local;Database=SchoolDb;Trusted_Connection=True;TrustServerCertificate=True;";
const string azureConnectionStirng =
    "Server=localhost;Database=SchoolDb;User Id=SA;Password=Amin389278200;TrustServerCertificate=True;Encrypt=False;";
builder.Services.AddDbContext<SchoolDb>(options => {
        options.UseSqlServer(azureConnectionStirng);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.Run();
