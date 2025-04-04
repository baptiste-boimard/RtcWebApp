using Microsoft.AspNetCore.SignalR;

namespace RtcWebApp.Hub;

public class WebRtcHub : Microsoft.AspNetCore.SignalR.Hub
{
    public async Task SendOffer(string offer) =>
        await Clients.Others.SendAsync("ReceiveOffer", offer);

    public async Task SendAnswer(string answer) =>
        await Clients.Others.SendAsync("ReceiveAnswer", answer);

    public async Task SendCandidate(string candidate) =>
        await Clients.Others.SendAsync("ReceiveCandidate", candidate);
}