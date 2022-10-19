using Notes.Client.Mvc.Models;

namespace Notes.Client.Mvc.Repository
{
    public interface INoteRepository
    {
        Task<bool> UpdateRepositoryAsync();

        Task<NoteModel> GetNoteByIdAsync(int id);

        IEnumerable<NoteModel> GetAllNotes();
    
        Task EditNote(NoteModel note);
        Task DeleteAsync(int id);
        Task CreateNoteAsync(NoteModel viewModel);
    }
}
