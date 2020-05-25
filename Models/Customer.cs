using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CId { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string CName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string CFirstName { get; set; }

        //Relation with Shopping Bag
        public int? ShoppingBagID { get; set; } 
        public ICollection<ShoppingBag> ShoppingBags { get; set; }

        // we do not want to keep this information in our DB as it is a calculate value
        [NotMapped] 
        [Display(Name = "Full name")]
        public string CFullName
        {
            get { return CFirstName + " " + CName; }
        }


    }
}
