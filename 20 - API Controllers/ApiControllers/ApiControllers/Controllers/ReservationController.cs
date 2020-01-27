using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiControllers.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace ApiControllers.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private IRepository repository;

        public ReservationController(IRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
            return repository.Reservations;
        }

        [HttpGet("{id}")]
        public Reservation Get(int id)
        {
            return repository[id];
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    Reservation result = repository[id];

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(result);
        //    }
        //}

        [HttpPost]
        public Reservation Post([FromBody] Reservation res)
        {
            Reservation result = new Reservation
            {
                ClientName = res.ClientName,
                Location = res.Location
            };

            return repository.AddReservation(result);
        }

        [HttpPut]
        public Reservation Put([FromBody] Reservation res)
        {
            Reservation result = repository.UpdateReservation(res);

            return result;
        }

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromBody]JsonPatchDocument<Reservation> patch)
        {
            Reservation res = Get(id);

            if (res != null)
            {
                patch.ApplyTo(res);

                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteReservation(id);
        }
    }
}