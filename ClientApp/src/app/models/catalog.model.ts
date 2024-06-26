export interface CatalogList {
  category: string,
  title: string,
  manufacturer: string;
  shopSku: string,
  description: string,
  price: number,
  salesPrice: number,
  imageUrl: string,
  googleId: number,
  trackingId: string,
  themeDesc: string,
  themeId: number,
  themeName: string,
  sizeDesc: string,
  colorId: number,
  additionalImages: string

}

export interface CatalogSummary {
  wwwRoot: string,
  itemCount: number,
  errorMessage: string
}
