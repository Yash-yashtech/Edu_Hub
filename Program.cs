using Edu_Hub_Project.Models;
using Edu_Hub_Project.Repository;
using Edu_Hub_Project.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MyConstr") ?? throw new InvalidOperationException("Connection string 'AppDBContextConnection' not found.");
 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
 
builder.Services.AddScoped<IUserService, UserRepository>();

builder.Services.AddScoped<ICourseService, CourseRepository>();

builder.Services.AddScoped<IMaterialService, MaterialRepository>();

builder.Services.AddScoped<IEnquiryService, EnquiryRepository>();

builder.Services.AddScoped<IFeedbackService, FeedbackRepository>();

builder.Services.AddScoped<IEnrollmentService, EnrollmentRepository>();

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseSession();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
