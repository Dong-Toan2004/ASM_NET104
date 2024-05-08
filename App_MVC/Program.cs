var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(option =>
{
    option.IOTimeout = TimeSpan.FromSeconds(15); // Khai báo thời gian để Session timeout mặc định 1200 giây
}); //Khai báo dịch vụ
// 1 phiên làm việc cho tới khi timeout sẽ đc tính từ request cuối cùng cho tới khi hết thời gian timeuot mà không có 
//Dữ liệu được lưu vào web server
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");//Set route m?ng đ?nh v? login 

app.Run();
