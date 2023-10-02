import { Injectable } from '@angular/core';
import { Orders } from '../Models/orders';
import { HttpClient, HttpHandler, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { jsDocComment } from '@angular/compiler';


@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  url: string =" https://localhost:7116/api/order";
  order!: Orders[];
  orders!: Orders;
  constructor( private httpClient:HttpClient) {
   
    
  }
  public GetOrder(): Observable<Orders[]> {
    var usertoken = String(localStorage.getItem('token') || '{}');
    var headers = new HttpHeaders();
     
    headers = headers.append('Authorization', "$Bearer { usertoken }");
    return this.httpClient.get<Orders[]>(this.url, { headers: headers });
      

    
  }
  public InsertOrder(orders: Orders) {
    var headers = new HttpHeaders();
    headers = headers.append(
      'Authorization', `Bearer ${localStorage["token"]}`);
    return this.httpClient.post(this.url, orders, { headers: headers });
   
  }
  //public EditOrder(orders: Orders) {
  //  return this.httpClient.put(this.url + "/" + this.orders.orderid, this.orders);
  //}
}
