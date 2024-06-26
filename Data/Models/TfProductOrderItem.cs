using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_ProductOrderItems")]
    public partial class TfProductOrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [StringLength(150)]
        public string ProductTitle { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int? OrderStatus { get; set; }
        public int? ProductType { get; set; }
        [Column("transactionId")]
        [StringLength(50)]
        public string TransactionId { get; set; }
        [StringLength(40)]
        public string RefId { get; set; }
        [Column("flagId")]
        public int? FlagId { get; set; }
        [Column("saleId")]
        public int? SaleId { get; set; }
        [Column("freeCollectionId")]
        public int? FreeCollectionId { get; set; }
        [Column("expirydate", TypeName = "datetime")]
        public DateTime? Expirydate { get; set; }
        [Column(TypeName = "money")]
        public decimal? OfferPrice { get; set; }
        public int? ItemGroupSizeId { get; set; }
    }
}
