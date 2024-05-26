using CraftX.Class;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

/*AppDbContext ����� �����ϱ�*/
//���ڿ��� ���� ����
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    // ���⿡ �����ͺ��̽� ���� ���ڿ� �Ǵ� �����ͺ��̽� �ɼ��� �����մϴ�.
//    options.UseSqlServer("Server=PREDATOR;Database=ProjectDB1;Encrypt=false;Trusted_Connection=True;MultipleActiveResultSets=True"); // SQL Server�� ����ϴ� ���
//});

//appsettings.json���� "DefaultConnection"�̶�� �̸��� ���� ���ڿ� ��������(���Ȼ� ����)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/*AppDbContext ����� �����ϱ�*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
