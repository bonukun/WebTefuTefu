using WebTefuTefu.Domains;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                          policy.WithOrigins("https://thankful-cliff-02d377510.3.azurestaticapps.net").AllowAnyHeader().AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddSingleton<IBibTeXParserInteractor,BibTeXParserInteractor>();
builder.Services.AddSingleton<IBibTeXMapConvertInteractor,BibTeXMapConvertInteractor>();



builder.Services.AddControllers();
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
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
