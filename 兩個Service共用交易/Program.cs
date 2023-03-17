using ���Service�@�Υ��.Models.Data;
using ���Service�@�Υ��.Models.Data.Context;
using ���Service�@�Υ��.Models.Repository;
using ���Service�@�Υ��.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyContext>((o) =>
{
    //�n��MSSQL���иѰ�������
    //o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    //�S���w�˥����Ʈw���иѰ�������
    //o.UseInMemoryDatabase("My")
    //.ConfigureWarnings(x => x.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.InMemoryEventId.TransactionIgnoredWarning));

    //�Ъ`�N��̹B�@���i��y�����P�A�Цۦ��[��
});

builder.Services.AddScoped<�b���A��>();
builder.Services.AddScoped<�|���A��>();

builder.Services.AddScoped<�|��Repository>();
builder.Services.AddScoped<�b��Repository>();

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
