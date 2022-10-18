using Notes.Client.Mvc.Models;

namespace Notes.Client.Mvc.Repository
{
    public interface INoteRepository
    {
        Task<bool> UpdateRepositoryAsync(string url);

        Task<NoteViewModel> GetNoteByIdAsync(int id);

        IEnumerable<NoteViewModel> GetAllNotes();
    
        Task EditNote(NoteViewModel note);
        Task DeleteAsync(int id);
        Task CreateNoteAsync(NoteViewModel viewModel);
    }
}
