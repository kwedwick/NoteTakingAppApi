using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteTaking.API.Models;
using NoteTakingApp.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteTaking.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {

        private string _text;
        private readonly IRepository _repo;

        public NotesController(IRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<NotesController>
        [HttpGet]
        public IActionResult Get()
        {
            var note = _repo.GetNotes();
            return Ok(note);
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var singleNote = _repo.GetNotes().First(x => x.Id == id);
                return Ok(singleNote);
            } catch
            {
                string message = $"Note not found with this ID: {id}";
                return Ok($"{message}");
            }
        }

        // POST api/<NotesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreatedNote newNote)
        {
            List<string> Tags;
            var note = new Note { Text = newNote.Text, Tags = newNote.Tags.ToList() };

            try
            {
                var dbnote = _repo.AddNote(note);
                return Ok(dbnote);
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError(key: "Text", errorMessage: e.Message);
                ModelState.AddModelError(key: "", errorMessage: "general errors could go up here");
                string errorMessage = $"Unable to create your new note {newNote}";
                return Ok(errorMessage);
            }

        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
