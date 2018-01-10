using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GillBobWedding.Models
{
    public enum RSVP { Attending, NotAttending, NotResponded }
    public class RoleCall
    {
        [Key]
       
        public string Name { get; set; } = string.Empty;
        public string PlusOneName { get; set; } = string.Empty;
       
        public RSVP RSVP { get; set; } = RSVP.NotResponded;
        public string Comment { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Name:, {Name}, PlusOne:, {PlusOneName}, RSVP:, {RSVP.ToString()}, Comment: {Comment}\n";
        }

        public async Task WriteCsv(string path,string rsvp )
        {
            await File.AppendAllTextAsync(path, rsvp);
        }
    }
}
