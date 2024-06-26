using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("CRM_ContactsNew")]
    public partial class CrmContactsNew
    {
        [Key]
        [Column("contactId")]
        public int ContactId { get; set; }
        [Column("GSM")]
        [StringLength(13)]
        public string Gsm { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        public int? StateId { get; set; }
        public int? CountryCode { get; set; }
        public int? Sex { get; set; }
        [Column("DOB", TypeName = "datetime")]
        public DateTime? Dob { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastContactDate { get; set; }
        [Column("isExistingCustomer")]
        public bool? IsExistingCustomer { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CustomerSince { get; set; }
        [Column("firstName")]
        [StringLength(15)]
        public string FirstName { get; set; }
    }
}
