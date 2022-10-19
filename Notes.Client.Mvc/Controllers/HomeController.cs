using Microsoft.AspNetCore.Mvc;
using Notes.Client.Mvc.Models;
using Notes.Client.Mvc.Repository;
using System.Diagnostics;

namespace Notes.Client.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INoteRepository noteRepository;

        public HomeController(ILogger<HomeController> logger, INoteRepository noteRepository)
        {
            _logger = logger;
            this.noteRepository = noteRepository;
        }

        public async Task<IActionResult> Index()
        {
           var result = await noteRepository.UpdateRepositoryAsync();
            if (!result)
                ViewBag.ErrorMessage = "Notes not found";
           return View(noteRepository.GetAllNotes());
           
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new NoteModel() { DateTimeModified = DateTime.Now};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NoteModel viewModel)
        {   
           await noteRepository.CreateNoteAsync(viewModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var note = await noteRepository.GetNoteByIdAsync(id);
            return View(note);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NoteModel model)
        {
            model.DateTimeModified = DateTime.Now;
            model.IsEdited = true;

            await noteRepository.EditNote(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await noteRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}