using EventsApplication.Services.Models;
using EventsLibrary.Models;
using EventsLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApplication.Service
{
    public interface ITicketService
    {
        //BuyTicketModel GetNewTicket();
        //BuyTicketModel GetTicketByEventId(int Id);
        // BuyTicketModel GetTicketById(int Id);

        void BuyTicket(BuyTicketModel BuyTicketModel);
        void RefundTheTicket(RefundTicketModel refundTicketModel);
        TicketListModel GetTicketWithIncludedCustomer(int Id);

    }
}
