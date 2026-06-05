
using Clinic.Care.DAL.Repositories.AppointmentRepo;
using Clinic.Care.DAL.Repositories.GenericRepo;
using Clinic.Care.DAL.Repositories.MedicalRecordRepo;
using Clinic.Care.DAL.Repositories.UntiOfWork;
using Clinic.Care.DAL.Repositories.UserRepo;
using ClinicCare.BLL.Services.AppointmentService;
using ClinicCare.DAL.Models;
using ClinicCare.BLL.Services.AuthService;
using ClinicCare.BLL.Services.MedicalRecordService;
using ClinicCare.BLL.Services.NotificationService;
using ClinicCare.BLL.Services.RoleService;
using ClinicCare.BLL.Services.UserService;
using ClinicCare.DAL.Data;
using ClinicCare.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString).UseLazyLoadingProxies()); 





builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAppointmentRepo,AppointmentRepo>();
builder.Services.AddScoped<IMedicalRecordRepo,MedicalRecordRepo>();
builder.Services.AddScoped<IUserRepo,UserRepo>();

builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IMedicalRecordService, MedicalRecordService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INotificationService, NotificationService>(); 


builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequiredLength = 6;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication(); 
app.UseAuthorization();
app.Run();





