using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Notes.Api.Data;
using Notes.Api.Entity;

namespace Notes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : Controller
    {
        [HttpGet]
        [Route("all")]
        public IActionResult All()
        {
            return Ok(ApiDbObject.GetAllNotes());
        }
        [HttpGet]
        [Route("getid/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(ApiDbObject.GetNoteById(id));
        }
        
        [Route("[action]")]
        public async Task<IActionResult> Edit(Note note)
        {
            //var note = JsonConvert.DeserializeObject<Note>(json.ToString());
            await ApiDbObject.EditNoteAsync(note);
            return Ok(note);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await ApiDbObject.DeleteNote(id);
            if(note != null) return Ok(note);
            return BadRequest("No found note");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add(Note note)
        {
            if (note == null) return BadRequest("Note is empty");
            await ApiDbObject.AddNote(note);
            return Ok(note);
        }
    }
}
