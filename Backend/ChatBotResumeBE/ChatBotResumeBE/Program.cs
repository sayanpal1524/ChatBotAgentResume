using ChatBotResumeBE.Orchestrator;
using ChatBotResumeBE.Services.AiProvider;
using ChatBotResumeBE.Services.AiProvider.Interface;
using ChatBotResumeBE.Services.ResumeParserService;
using ChatBotResumeBE.Services.ResumeParserService.Interface;
using ChatBotResumeBE.Util.Entity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

// Services
builder.Services.AddControllers();
builder.Services.AddScoped<IChatOrchestrator, ChatOrchestrator>();
builder.Services.AddScoped<OpenAiProvider>();
builder.Services.AddScoped<SarvamAiProvider>();
builder.Services.AddScoped<Func<string, IAiProvider>>(serviceProvider => key =>
{
    return key switch
    {
        "openai" => serviceProvider.GetRequiredService<OpenAiProvider>(),
        "sarvam" => serviceProvider.GetRequiredService<SarvamAiProvider>(),
        _ => throw new ArgumentException("Invalid provider key")
    };
});
builder.Services.AddScoped<IResumeParser, ResumeParserService>();
builder.Services.AddDbContext<ResumeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDBConnection")));
builder.Services.AddHttpClient();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("http://localhost:5173") // React dev server
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
