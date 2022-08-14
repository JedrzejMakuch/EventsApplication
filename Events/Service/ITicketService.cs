using EventsLibrary.Models;
using EventsLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsLibrary.Service
{
    public interface ITicketService
    {
        IQueryable<Ticket> GetTicketWithIncludedCustomer(int Id);
        Ticket GetNewTicket();
        void BuyTicket(BuyTicketFormViewModel buyTicketFormViewModel, int Id);
        Ticket GetTicketByEventId(int Id);
        void RefundTheTicket(ReturnTicketFormViewModel returnTicketFormViewModel);
        Ticket GetTicketById(int Id);
    }
}
