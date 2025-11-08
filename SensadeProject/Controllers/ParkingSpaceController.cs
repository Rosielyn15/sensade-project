using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SensadeProject.Models;

namespace SensadeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpaceController : ControllerBase
    {
        private static List<Parkingspace> spaces = new List<Parkingspace>();
        private static int nextId = 1;

        [HttpGet]
        public ActionResult<List<Parkingspace>> GetAllParkingSpaces()
        {
            return spaces;
        }

        [HttpGet("{id}")]
        public ActionResult<Parkingspace> GetSpaceById(int id)
        {
            var space = spaces.FirstOrDefault(s => s.id == id);
            if (space == null) return NotFound();
            return space;
        }

        [HttpGet("lot/{lotId}")]
        public ActionResult<List<Parkingspace>> GetSpacesByLot(int lotId)
        {
            var filtered = spaces.Where(s => s.id == lotId).ToList();
            return filtered;
        }
        [HttpPost("lot/{lotId}")]
        public ActionResult<Parkingspace> AddSpaceToLot(int lotId, Parkingspace newSpace)
        {
            newSpace.id = nextId++;
            newSpace.id = lotId;
            spaces.Add(newSpace);
            return CreatedAtAction(nameof(GetSpaceById), new { id = newSpace.id }, newSpace);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSpace(int id, Parkingspace updatedSpace)
        {
            var space = spaces.FirstOrDefault(s => s.id == id);
            if (space == null) return NotFound();

            space.spaceNumber = updatedSpace.spaceNumber;
            space.status = updatedSpace.status;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpace(int id)
        {
            var space = spaces.FirstOrDefault(s => s.id == id);
            if (space == null) return NotFound();

            spaces.Remove(space);
            return NoContent();
        }
        [HttpPut("{id}/status")]
        public IActionResult UpdateParkingSpaceStatus(int id, [FromBody] string newStatus)
        {
            var space = spaces.FirstOrDefault(s => s.id == id);
            if (space == null) return NotFound();

            space.status = newStatus;

            return NoContent();
        }
        
        

    }
}
