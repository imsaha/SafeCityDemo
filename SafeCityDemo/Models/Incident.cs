using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeCityDemo.Models
{
    [Table("tblIncidents")]
    public class Incident
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string CallerNumber { get; set; }
        public string CallerName { get; set; }
        public DateTime Date { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public int CategoryId { get; set; }


        [ForeignKey(nameof(LocationId))]
        public Location Location { get; set; }
        public int LocationId { get; set; }
    }
}
