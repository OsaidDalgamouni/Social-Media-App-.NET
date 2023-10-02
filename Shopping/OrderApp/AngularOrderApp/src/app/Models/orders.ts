import { Data } from "@angular/router";

export class Orders {
  orderid: number | null;
  customername: string | null;
  totalamount: number | null;
  orderdate: Data | null;

  
  constructor(orderId: number | null,
    customername: string | null,
    totalamount: number | null,
    orderdate: Data | null
   ) {
    this.orderid = orderId;
    this.customername = customername;
    this.totalamount = totalamount;
    this.orderdate = orderdate;
   
  }
}
