using Coravel;
using Coravel.Scheduling.Schedule;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();
builder.Services.AddScheduler();
var app =builder.Build();
