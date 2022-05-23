using AddressBookAPI.BLL.Interfaces;
using AddressBookAPI.BLL.Services;
using AddressBookAPI.DAL.Data;
using AddressBookAPI.DAL.Entities;
using AddressBookAPI.DAL.Interfaces;
using AddressBookAPI.DAL.Repository;
using AddressBookAPI.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IDataProvider<User>, UsersDataProvider>();
builder.Services.AddSingleton<IDataProvider<UserAddress>, UsersAddressesDataProvider>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserAddressRepository, UserAddressRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUriService>(o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(uri);
});
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserAddressService, UserAddressService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// global error handler
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();


app.Run();
