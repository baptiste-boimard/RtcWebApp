using RtcWebApp.Hub;

var builder = WebApplication.CreateBuilder(args);

// 👇 On force Kestrel à écouter sur 5450
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5450); // écoute sur le port 5450
});

builder.Services.AddSignalR();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<WebRtcHub>("/webrtc");

app.Run();