using CraftX.Class;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

/*AppDbContext 만든거 연결하기*/
//문자열로 직접 연결
//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    // 여기에 데이터베이스 연결 문자열 또는 데이터베이스 옵션을 설정합니다.
//    options.UseSqlServer("Server=PREDATOR;Database=ProjectDB1;Encrypt=false;Trusted_Connection=True;MultipleActiveResultSets=True"); // SQL Server를 사용하는 경우
//});

//appsettings.json에서 "DefaultConnection"이라는 이름의 연결 문자열 가져오기(보안상 좋음)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/*AppDbContext 만든거 연결하기*/

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
