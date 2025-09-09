using EduPortal.DataBase;
using EduPortal.Interface;
using EduPortal.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite("Data source = EduPortal.db"));

    // Регистрация сервисов
    builder.Services.AddScoped<IStudentService, StudentService>();
    builder.Services.AddScoped<ITeacherService, TeacherService>();
    builder.Services.AddScoped<ICourseService, CourseService>();
    builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();

    builder.Services.AddControllersWithViews();
}
var app = builder.Build();
{
    app.UseStaticFiles();

    app.MapControllers();
    app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}