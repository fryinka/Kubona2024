export interface Prodlist {
  itemGroupId: number;
  departmentId: number;
  title: string;
  sizeDesc: string;
  colorDesc: string;
  departmentName: string;
  numAvailable: number;
  styleDesc: string;
  colorId: number;
  trackingId: string;
  brandId: number;
  styleId: number;
  internetPrice: number;
  storePrice: number;
  similarId: string;
  image1Url: string;
  image2Url: string;
  numOfViews: number;
  description: string;
  youTubeId: string;
  tfItemsgroupSizes: Sizelist[];
  destinationUrl: string;
  positionId: number;
  materialId: number;
  heelHeightId: number;
  heelHeight: string;
}

export interface DepartmentGroup {
  departmentId: number;
  description: string;
  totalCount: number;
  destinationUrl: string;
}

export interface SizeGroup {
  sizeCode: number;
  sizeDesc: string;
  totalcount: number;
  destinationUrl: string;
}

export interface IComplexItem {
  uniqueIdentifier: number;
  extraData: any;
}

export interface ProductImages {
  orderId: number;
  image: string;
  thumbImage: string;
  alt: string;
  title: string;
}

export interface Sizelist {
  itemGroupSizeId: number;
  itemGroupId: number;
  sizeDesc: string;
  sizeCode: number;
  trackingId: string;
  quantity: number;
}

export interface RecentlyViewed {
  itemId: number;
  title: string;
  imageUrl: string;
  internetPrice: number;
  urlId: string;
  viewDate: Date;
}

export interface ColorsGroup {
  colorId: number;
  colorDesc: string;
  totalcount: number;
  destinationUrl: string;
}

export interface StylesGroup {
  styleId: number;
  styleDesc: string;
  totalcount: number;
  destinationUrl: string;
}

export interface HeelHeightGroup {
  heelHeightId: number;
  heelHeightDesc: string;
  totalCount: number;
  destinationUrl: string;
}
export interface MaterialGroup {
  materialId: number;
  materialDesc: string;
  totalCount: number;
  destinationUrl: string;
}

export interface OtherColors {
  title: string;
  mobileImageUrl: string;
  urlId: string;
  internetPrice: number;
}

export interface MenuLinks {
  linkId: number;
  shortTitle: string;
  routeId: string;
  routeUrl: string;
}

export interface RelatedProducts {
  itemgroupId: number,
  title: string,
  internetPrice: number,
  imageUrl: string,

  urlId: string
}

export interface CategoryTitle {
  categoryId: number;
  categoryDesc: string;
  urlId: string;
}

export interface USSize {
  value: number;
}
export interface sizeChart {
  usSize: number;
  ukSize: number;
  euroSize: string;
  genderId: number;
}

export interface Reply {
  reviewId: number;
  rating: number;
  customerGSM: string;
  response: string;
  dateAdded: Date;
}

export interface Reviews {
  reviewId: number;
  customerGsm: string;
  reviewerName: string;
  productId: number;
  sizeFit: string;
  trackingId: string;
  stateId: number;
  rating: number;
  reviewTitle: string;
  fullReview: string;
  productTitle: string;
  dateAdded: Date;
  addedDate: Date;
  datePurchased: Date;
  isApproved: boolean;
  isCustomer: boolean;
}

export interface PriceRange {
  price: string;
  desc: string;
  destinationUrl: string;
}

export interface HeelHeight {
  heelHeightId: number;
  desc: string;
}
export interface CustDetails {
  curationId: string;
  customerName: string;
}

export interface CuratedForCust {
  itemgroupId: number;
  title: string;
  internetPrice: number;
  imageUrl: string;
  destinationUrl: string;
}