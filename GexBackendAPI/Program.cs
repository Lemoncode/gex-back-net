using ApplicationLayer.UseCases;
using AdapterLayer.Repository;
using AdapterLayer.MongoDb;
using ApplicationLayer.Interfaces;
using AdapterLayer.Models;
using AdapterLayer.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependencies
builder.Services.AddScoped<MongoConnectionService>();
builder.Services.AddScoped<UserMapper>();
builder.Services.AddScoped<IRepository<UserModel>, Repository>();
builder.Services.AddScoped<GetUsers<UserModel>>();
builder.Services.AddScoped<AddUser<UserModel>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/users", async (GetUsers<UserModel> getUsers) =>
{
    var usersCollection =  await getUsers.ExecuteAsync();
    return usersCollection.Select(u => new UserView {
        Id = u._id,
        nombre = u.nombre,
        apellidos = u.apellidos,
        email = u.email,
        rol = u.rol
    });

})
.WithName("GetAllUsers")
.WithOpenApi();

app.MapPost("/api/users", async (UserRequest request, UserMapper mapper, AddUser<UserModel> addUser) =>
{
    var newUser = mapper.ToModel(request);
    await addUser.ExecuteAsync(newUser);
})
.WithName("InsertUser")
.WithOpenApi();

app.Run();
