using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAuth.Model
{
    public enum Sex
    {
        Male,
        Female
    }

    public class Credential
    {
        [Key]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty Password")]
        public string PasswordHash { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty mail")]
        [Index(IsUnique = true)]
        [Column(TypeName = "VARCHAR")]
        public string Mail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty sex")]
        public Sex Sex { get; set; }
    }
}
