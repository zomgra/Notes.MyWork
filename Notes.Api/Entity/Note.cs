using System.ComponentModel.DataAnnotations;

namespace Notes.Api.Entity
{
    public class Note
    {
        
        public int Id { get; set; }
        [MaxLength(25)]
        public string Title { get; set; }
        [MaxLength(125)]
        public string Description { get; set; }

    }
}
