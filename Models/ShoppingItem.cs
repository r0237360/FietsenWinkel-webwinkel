using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class ShoppingItem
    {

        [Key]
        public int SIId { get; set; }

        
        public int SIQuantity { get; set; }

        // SI has a relation with SB 
        public int SBId { get; set; } 
        public ShoppingBag ShoppingBag { get; set; }

        // SI has a relation with P
        public int PId { get; set; } 
        public Product Product { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SISubTotal { get; set; }
                         


    }
}
