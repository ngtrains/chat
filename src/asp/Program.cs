using ServiceReference;

EchoServiceClient client = new EchoServiceClient();
var simpleResult = await client.EchoAsync("Hello");

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => simpleResult);

app.Run();
