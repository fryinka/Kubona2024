using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Kubona.Data.Models
{
    public class TfItemsGroupDTO
    {
        public TfItemsGroupDTO() { }
        public int itemGroupId { get; set; }
        public int? departmentId { get; set; }
        public string Title { get; set; }
        public string sizeDesc { get; set; }
        public string colorDesc { get; set; }
        public string departmentName { get; set; }

        public int? numAvailable { get; set; }
        public string styleDesc { get; set; }

        public int? colorId { get; set; }

        public int? brandId { get; set; }
        public int? styleId { get; set; }
        public decimal? internetPrice { get; set; }
        public decimal? storePrice { get; set; }

        public int? numOfViews { get; set; }

        public int lft { get; set; }
        public int rgt { get; set; }

        public string image1Url { get; set; }

        public string image2Url { get; set; }

        public string destinationUrl { get; set; }

        public DateTime? addedDate { get; set; }

        public int? positionId { get; set; }
        public string similarId { get; set; }
        public int? heelHeightId { get; set; }
        public int? materialId { get; set; }
    }
}