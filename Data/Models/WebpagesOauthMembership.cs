﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    [Table("webpages_OAuthMembership")]
    public partial class WebpagesOauthMembership
    {
        [Key]
        [StringLength(30)]
        public string Provider { get; set; }
        [Key]
        [StringLength(100)]
        public string ProviderUserId { get; set; }
        public int UserId { get; set; }
    }
}
