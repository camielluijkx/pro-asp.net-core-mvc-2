using System.Collections.Generic;

namespace PartyInvites.Models
{
    public class EFRepository : IRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<GuestResponse> Responses
        {
            get
            {
                return context.Invites;
            }
        }

        public void AddResponse(GuestResponse response)
        {
            context.Invites.Add(response);
            context.SaveChanges();
        }
    }
}