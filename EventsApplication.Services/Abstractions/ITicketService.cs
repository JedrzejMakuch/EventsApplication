using EventsApplication.Services.Models;

namespace EventsApplication.Service
{
    public interface ITicketService
    {
        void BuyTicket(BuyTicketModel BuyTicketModel);

        void RefundTheTicket(RefundTicketModel refundTicketModel);

        TicketListModel GetTicketWithIncludedCustomer(int Id);

    }
}
