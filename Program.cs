var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.MapGet("/math", (int a, int b) => { 
    return "The sum of " + a + " + " + b + " is " + (a+b); 
});

app.MapGet("/name&time", (string name, string time) => {
    return "This is " + name + " & " + "they woke up at " + time;
});

app.MapGet("/BiggerThan", (int a, int b) => {
   if (a == b){
    return a + " is equal to " + b;
   }
   else if (a < b){
    return a + " is less than " + b;
   }
   else{
    return a + " is greater than " + b;
   }
});

app.Run();