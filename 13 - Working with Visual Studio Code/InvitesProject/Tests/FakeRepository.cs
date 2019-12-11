using PartyInvites.Models;
using System;
using System.Collections.Generic;

namespace Tests
{
    internal class FakeRepository : IRepository
    {
        public IEnumerable<GuestResponse> Responses { get; } 
            = new List<GuestResponse>
            {
                new GuestResponse { Name = "Bob", WillAttend = true },
                new GuestResponse { Name = "Alice", WillAttend = true },
                new GuestResponse { Name = "Joe", WillAttend = false }
            };

        public void AddResponse(GuestResponse response)
        {
            throw new NotImplementedException();
        }
    }
}