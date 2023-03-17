using 兩個Service共用交易.Models.Data;
using 兩個Service共用交易.Models.Data.Context;
using 兩個Service共用交易.Models.Repository;
using 兩個Service共用交易.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyContext>((o) =>
{
    //要用MSSQL的請解除此註解
    //o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    //沒有安裝任何資料庫的請解除此註解
    //o.UseInMemoryDatabase("My")
    //.ConfigureWarnings(x => x.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.InMemoryEventId.TransactionIgnoredWarning));

    //請注意兩者運作中可能稍有不同，請自行觀測
});

builder.Services.AddScoped<帳號服務>();
builder.Services.AddScoped<會員服務>();

builder.Services.AddScoped<會員Repository>();
builder.Services.AddScoped<帳號Repository>();

builder.Services.AddScoped<UnitOfWork>();

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
