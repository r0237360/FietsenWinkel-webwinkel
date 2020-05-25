using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId{ get; set; }

        [Required]
        [Display(Name = "Product name")]
        public string PName { get; set; }

        [Display(Name = "Price")]
        public decimal PPrice { get; set; }


    }
}
