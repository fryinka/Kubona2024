using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("TF_New_Cust_Order_Verify")]
    public partial class TFNewCustOrderVerify
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("OrderId")]
        public int OrderId { get; set; }
        [Column("AmountEntered", TypeName = "money")]
        public decimal AmountEntered { get; set; }
    }
}
