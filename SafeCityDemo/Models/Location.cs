using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeCityDemo.Models
{
    [Table("tblLocations")]
    public class Location {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

    }
}
