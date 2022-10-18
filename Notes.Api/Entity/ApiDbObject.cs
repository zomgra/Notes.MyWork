using Microsoft.EntityFrameworkCore;
using Notes.Api.Data;
using System.Diagnostics;

namespace Notes.Api.Entity
{
    public class ApiDbObject
    {
        private static ApiDbContext _context;
        internal static void Initial(ApiDbContext? apiDbContext)
        {
            _context = apiDbContext;
            InitialDbData();
        }

        //Инициализация БД
        private static void InitialDbData()
        {
            _context.Add(new Note { Id = 1, Title = "Продукты", Description = "Купить 10 яиц" , DateTimeModified = DateTime.Now});
            _context.SaveChanges();
        }

        //Get
        public static IEnumerable<Note> GetAllNotes() => _context.Notes;
        public static Note GetNoteById(int id) => _context.Notes.First(n => n.Id == id);
        public static Note GetLastNote() => _context.Notes.Last();

        //Create 
        public static async Task AddNote(Note newNote)
        {
            await _context.Notes.AddAsync(newNote);
            await _context.SaveChangesAsync();
        }
        
        //Edit
        public static async Task EditNoteAsync(Note editedNote)
        {

           var note = await _context.Notes.FirstOrDefaultAsync(i => i.Id == editedNote.Id);
            if(note != null)
            {
                 _context.Notes.Remove(note);
               await _context.Notes.AddAsync(editedNote);
                //_context.Notes.Update(editedNote);
                await _context.SaveChangesAsync();
            }
        }
        public static async Task<Note> DeleteNote(int id)
        {
            var note = GetNoteById(id);
            if(note != null)
                _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
            return note;
        }

    }
}
