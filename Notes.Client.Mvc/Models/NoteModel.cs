using System.ComponentModel.DataAnnotations;

namespace Notes.Client.Mvc.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTime DateTimeModified { get; set; }

        public bool IsEdited { get; set; } = false;

    }
}
