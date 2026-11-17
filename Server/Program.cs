using BlazorScheduler.Server.Data;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver=new DefaultContractResolver();
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
    options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    options.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Ignore;
    options.SerializerSettings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
});
builder.Services.AddCors(o => o.AddDefaultPolicy(p => p.WithOrigins("https://localhost:7100", "http://localhost:5100").AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddDbContext<SchedulerContext>(context => context.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + "\\App_Data\\ScheduleData.mdf;Integrated Security=True;Connect Timeout=30"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler(e => e.Run(c => { c.Response.StatusCode = 500; return Task.CompletedTask; }));
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors();

app.MapControllers();

app.Run();
