
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Notes.Client.Mvc.Models;
using System;
using System.Net.Http.Headers;

namespace Notes.Client.Mvc.Repository
{

    public class NoteRepository : INoteRepository
    {
        private IEnumerable<NoteViewModel> _notes = new List<NoteViewModel>();

        public async Task CreateNoteAsync(NoteViewModel viewModel)
        {
            var noteClient = new HttpClient();
            var url = "https://localhost:8001/api/note/add/";
            var responce = await noteClient.PostAsJsonAsync(url, viewModel);    
        }

        public async Task DeleteAsync(int id)
        {
            var noteClient = new HttpClient();
            var url = "https://localhost:8001/api/note/delete/" + id;
            var responce = await noteClient.DeleteAsync(url);

        }

        public async Task EditNote(NoteViewModel note)
        {
            var noteClient = new HttpClient();
            var url = "https://localhost:8001/api/note/edit";

            noteClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await noteClient.PostAsJsonAsync(url, note);

        }

        //    public NoteRepository()
        //    {
        //        _notes = new List<NoteViewModel>()
        //        {
        //            new NoteViewModel
        //            {
        //                Id = 1,
        //                Title = "Title 1",
        //                Description = "Description 1"
        //            },
        //            new NoteViewModel
        //            {
        //                Id = 2,
        //                Title = "Title 2",
        //                Description = "Description 2"
        //            },
        //            new NoteViewModel
        //            {
        //                Id = 3,
        //                Title = "Title 3",
        //                Description = "Description 3"
        //            },
        //            new NoteViewModel
        //            {
        //                Id = 4,
        //                Title = "Title 4",
        //                Description = "Description 4"
        //            }

        //        };
        //    }

        public IEnumerable<NoteViewModel> GetAllNotes() => _notes.ToList();

        public async Task<NoteViewModel> GetNoteByIdAsync(int id)
        {
            var noteClient = new HttpClient();
            var url = "https://localhost:8001/api/note/getid/" + id;

            var streamResult = await noteClient.GetStringAsync(url);
            var note = JsonConvert.DeserializeObject<NoteViewModel>(streamResult);
            if (note == null) return null;
            return note;
        }

        public async Task<bool> UpdateRepositoryAsync(string url)
        {
            var noteClient = new HttpClient();
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
