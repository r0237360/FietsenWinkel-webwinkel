using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class ShoppingBag
    {
        [Key]
        public int SBId { get; set; }

        [Required]
        [DisplayName("Order Date")]
        [DataType(DataType.Date)]
        public DateTime SBDate { get; set; }

        //SB has a relation with C (relation is 1 to 1)
        [DisplayName("Customer")]
        public int CId { get; set; } 
        public Customer Customer { get; set; }

        //SB has a relation with SI (relation is 1 to 0 or many)
        [DisplayName("Item")]
        [DisplayFormat(NullDisplayText = "No item")]
        public int? SIId { get; set; } 
        public ICollection<ShoppingItem> ShoppingItems { get; set; }
             


        [NotMapped]
        public int SBTotalQuantity { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SBSubTotal { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SBDiscountPct { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SBDiscount { get; set; }

        [NotMapped]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SBTotal { get; set; }
    }



}

