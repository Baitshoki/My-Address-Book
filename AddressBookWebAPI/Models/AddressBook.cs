using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookWebAPI.Models
{
    public class AddressBook
    {
        [Key]
        public int ID { get; set; }
       // [Required(AllowEmptyStrings = true)]
       // [Column(TypeName ="nvarchar(30")]
        public string FirstName { get; set; }
      
        [Column(TypeName = "nvarchar(30)")]
        public string Surname { get; set; }
      
        [Column(TypeName = "nvarchar(14)")]
        public string Telephone { get; set; }
      
        [Column(TypeName = "nvarchar(14)")]
        public string CellNumber { get; set; }
     
        [Column(TypeName = "nvarchar(30)")]
        public string EmailAddress { get; set; }
      //  [Required(AllowEmptyStrings = true)]
        [Column(TypeName = "nvarchar(10)")]
        public string UpdatedDate { get; set; }

    }
}
