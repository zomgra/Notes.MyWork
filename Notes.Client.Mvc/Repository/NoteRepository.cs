using Newtonsoft.Json;
using Notes.Client.Mvc.Models;
using System.Net.Http.Headers;

namespace Notes.Client.Mvc.Repository
{

    public class NoteRepository : INoteRepository
    {
        private IEnumerable<NoteViewModel> _notes = new List<NoteViewModel>();
        private readonly string baseUrl = "https://localhost:8001/api/note/";

        public async Task CreateNoteAsync(NoteViewModel viewModel)
        {
            var noteClient = new HttpClient();
            var url = baseUrl + "add/";
            var responce = await noteClient.PostAsJsonAsync(url, viewModel);    
        }

        public async Task DeleteAsync(int id)
        {
            var noteClient = new HttpClient();
            var url = baseUrl + "delete/" + id;
            
            var responce = await noteClient.DeleteAsync(url);

        }

        public async Task EditNote(NoteViewModel note)
        {

            var noteClient = new HttpClient();
            var url = baseUrl + "edit";

            noteClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await noteClient.PostAsJsonAsync(url, note);

        }

        public IEnumerable<NoteViewModel> GetAllNotes() => _notes.ToList();

        public async Task<NoteViewModel> GetNoteByIdAsync(int id)
        {
            var noteClient = new HttpClient();
            var url = baseUrl + "getid/" + id;

            var streamResult = await noteClient.GetStringAsync(url);
            var note = JsonConvert.DeserializeObject<NoteViewModel>(streamResult);
            if (note == null) return null;
            return note;
        }

        public async Task<bool> UpdateRepositoryAsync()
        {
            var noteClient = new HttpClient();
            var url = baseUrl + "all";
            var streamResult = await noteClient.GetStringAsync(url);
            var jsonNotes = JsonConvert.DeserializeObject<List<NoteViewModel>>(streamResult);
            
            if(jsonNotes == null)
            {
                return false;
            }
            _notes = jsonNotes;
            return true;
        }
    }
}
