using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zaliczenie_.net.Models
{
    public class Library
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idBook { get; set; }
        [Required]
        [MaxLength(30)]
        [RegularExpression(@"^[A-ZŁŚ]\w.*", ErrorMessage = "The field Tittle must start with capital letter")]
        public string Tittle { get; set; }
        [Required]
        [MaxLength(30)]
        [RegularExpression(@"^[A-ZŁŚ]\w.*", ErrorMessage = "The field Author must start with capital letter")]
        public string Author { get; set; }
        [Required]
        [MaxLength(30)]
        public string Section { get; set; }
        [Required(ErrorMessage = "The Status field is required.")]
        public Status Status { get; set; }
    }
    public enum Status
    {
        Available,
        Unavailable
    }
    
}
