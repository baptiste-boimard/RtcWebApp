using RtcWebApp.Hub;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(7162, listenOptions =>
    {
        listenOptions.UseHttps("cert.pem", "key.pem");
    });
});

builder.Services.AddSignalR();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<WebRtcHub>("/webrtc");

app.Run();