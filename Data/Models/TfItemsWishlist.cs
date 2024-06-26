using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_Items_Wishlist")]
    public partial class TfItemsWishlist
    {
        [Key]
        public int WishListId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AddedDate { get; set; }
    }
}
