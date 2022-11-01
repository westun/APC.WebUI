using Microsoft.AspNetCore.Authentication;

namespace APC.WebUI.Authentication.EventHandlers
{
    public interface IOnTicketReceived
    {
        Task Execute(TicketReceivedContext context);
    }
}