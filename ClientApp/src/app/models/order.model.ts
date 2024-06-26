export interface Cartlist {
  orderItemId: number,
  mobileImageUrl: string,
  itemGroupId: number,
  quantity: number,
  title: string,
  internetPrice: number,
  numAvailable: number,
  departmentId: number,
  size: string,
  trackingId: string,
  departmentName: string,
  productId: string,
  categoryId: string,
  color:string
}

export interface ActiveOrder {
  userId: string,
  orderId: number,
  totalValue: number,
  totalItems: number
}

export interface CheckoutData {
  whatsAppUrl: string,
  orderId: number
}
