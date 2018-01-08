using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GillBobWedding.Models
{
    public enum RSVP { Attending, NotAttending }
    public class RoleCall
    {
        [Key]
        [Required]
        public string Name { get; set; } = string.Empty;
        public string PlusOneName { get; set; } = string.Empty;
        [Required]
        public RSVP RSVP { get; set; }
        public string Accommodation { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Name:, {Name}, PlusOne:, {PlusOneName}, RSVP:, {RSVP.ToString()}, Accommodation:, {Accommodation}, Comment: {Comment}\n";
        }

        public async Task WriteCsv(string path,string rsvp )
        {
            await File.AppendAllTextAsync(path, rsvp);
        }
    }
}
