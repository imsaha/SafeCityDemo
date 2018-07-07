using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafeCityDemo.Models
{
    [Table("tblCategories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }
}
