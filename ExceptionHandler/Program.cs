using ExceptionHandler.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<ExcepitonMiddleware>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseDeveloperExceptionPage();
}
else
{
    //open this comment block for using UseExceptionHandler without IExceptionHandler

    //app.UseExceptionHandler(errorApp =>
    //{
    //    errorApp.Run(async context =>
    //    {
    //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
    //        context.Response.ContentType = "text/html";

    //        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    //        if (exceptionHandlerPathFeature?.Error != null)
    //        {
    //            var logger = app.Services.GetRequiredService<ILogger<Program>>();
    //            logger.LogError($"Something went wrong: {exceptionHandlerPathFeature.Error.Message}");
    //        }

    //        await context.Response.WriteAsync(exceptionHandlerPathFeature.Error.Message).ConfigureAwait(false);
    //    });
    //});

    

}

app.UseExceptionHandler();
app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
