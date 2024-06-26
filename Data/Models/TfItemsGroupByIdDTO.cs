using System.Collections.Generic;


namespace Kubona.Data.Models
{
    public class TfItemsGroupByIdDTO
    {
        public TfItemsGroupByIdDTO() { }
        public int itemGroupId { get; set; }
        public int? departmentId { get; set; }
        public string Title { get; set; }
        public string sizeDesc { get; set; }
        public string colorDesc { get; set; }
        public string departmentName { get; set; }

        public int? numAvailable { get; set; }
        public string styleDesc { get; set; }

        public int? colorId { get; set; }

        public string trackingId { get; set; }

        public int? brandId { get; set; }
        public decimal? internetPrice { get; set; }
        public decimal? storePrice { get; set; }

        public int? numOfViews { get; set; }

        public int lft { get; set; }
        public int rgt { get; set; }

        public string destinationUrl { get; set; }

        public string similarId { get; set; }

        public string description { get; set; }

        public string youTubeId { get; set; }
        public int? materialId { get; set; }
        public int? heelHeightId { get; set; }
        public string heelHeight { get; set; }

        //public ICollection<TfItemsgroupSize> tfItemsgroupSizes { get; set; }

        //public ICollection<TfItemsImage> tfItemsgroupImages { get; set; }


    }
}