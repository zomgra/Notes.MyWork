using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Notes.Api.Entity
{
    public class Note
    {
        
        public int Id { get; set; }
        [MaxLength(25)]
        public string Title { get; set; }
        [MaxLength(125)]
        public string Description { get; set; }
        public DateTime DateTimeModified { get; set; }

    }
}
