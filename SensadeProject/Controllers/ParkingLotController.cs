using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensadeProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace SensadeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {
        public static List<Parkinglot> lots = new List<Parkinglot>();
        private static int nextId = 1;
        [HttpGet]
        public ActionResult<List<Parkinglot>> GetAllLots()
        {
            return lots;
        }

        [HttpGet("{id}")]
        public ActionResult<Parkinglot> GetLotById(int id)
        {
            var lot = lots.FirstOrDefault(l => l.id == id);
            if (lot == null) return NotFound();
            return lot;
        }
        [HttpPost]
        public ActionResult<Parkinglot> CreateLot(Parkinglot newLot)
        {
            newLot.id = nextId++;
            lots.Add(newLot);
            return CreatedAtAction(nameof(GetLotById), new { id = newLot.id }, newLot);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateLot(int id, Parkinglot updatedLot)
        {
            var lot = lots.FirstOrDefault(l => l.id == id);
            if (lot == null) return NotFound();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteLot(int id)
        {
            var lot = lots.FirstOrDefault(l => l.id == id);
            if (lot == null) return NotFound();

            lots.Remove(lot);
            return NoContent();
        }
        [HttpGet("lot/{lotId}/summary")]
        public ActionResult<object> GetLotSpaceSummary(int lotId)
        {
            var lot = lots.FirstOrDefault(l => l.id == lotId);
            if (lot == null) return NotFound();

            var totalSpaces = lot.parkingspaces.Count;
            var freeSpaces = lot.parkingspaces.Count(s => s.status.Equals("free", System.StringComparison.OrdinalIgnoreCase));

            return Ok(new
            {
                LotId = lotId,
                TotalSpaces = totalSpaces,
                FreeSpaces = freeSpaces
            });
        }
    }
}