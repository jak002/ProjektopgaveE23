using ProjektopgaveE23.Interfaces;
using ProjektopgaveE23.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IUserRepository,UserRepository>();


builder.Services.AddTransient<IEventRepository,EventRepository>();


builder.Services.AddTransient<IBoatRepository, BoatRepository>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IEventBookingRepo, EventBookingRepo>();


builder.Services.AddTransient<IBoatBookingRepository, BoatBookingRepository>();

builder.Services.AddTransient<IBlogRepository, BlogRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
