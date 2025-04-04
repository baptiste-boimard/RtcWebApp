using RtcWebApp.Hub;

var builder = WebApplication.CreateBuilder(args);

// 🔒 Kestrel écoute sur 7162 en HTTPS avec .pfx
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(7162, listenOptions =>
    {
        listenOptions.UseHttps("certificat.pfx", "js4life"); // 🟡 Remplace par ton vrai mot de passe
    });
});

builder.Services.AddSignalR();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<WebRtcHub>("/webrtc");

app.Run();