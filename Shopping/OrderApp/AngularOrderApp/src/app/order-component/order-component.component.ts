import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { Orders } from '../Models/orders';
import { OrdersService } from '../services/orders.service';

@Component({
  selector: 'app-order-component',
  templateUrl: './order-component.component.html',
  styleUrls: ['./order-component.component.css']
})
export class OrderComponentComponent implements OnInit {
  orders: Orders[] = [];
  PostOrderForm: FormGroup;
  PutOderForm: FormGroup;
  editOrderId: number | null = null;

  constructor(public orderService: OrdersService) {
    this.PostOrderForm = new FormGroup({
      customername: new FormControl(''),
      orderdate: new FormControl(''),
      totalamount: new FormControl('')

    })
    this.PutOderForm = new FormGroup({
      orders: new FormArray([])
    });



  }
  get putOrderFromArr(): FormArray {
    return this.PutOderForm.get('orders') as FormArray;
  }
  loadOrder(): void {
    this.orderService.GetOrder().subscribe({
      next: (response: Orders[]) => {
        this.orders = response;
        this.orders.forEach(city => {
          this.putOrderFromArr.push(new FormGroup({
            orderId: new FormControl(city.orderid),
            customername: new FormControl(city.customername),
            orderdate: new FormControl(city.orderdate),
            totalamount: new FormControl({ value: city.totalamount, disabled: true })


          }));

        });
      },
      error: (error: any) => {
        console.log(error);
      },
      complete: () => { }

    });


  }
  ngOnInit(): void {
    this.loadOrder();

  }
  PostOrderSubmit() {
    this.orderService.InsertOrder(this.PostOrderForm.value).subscribe(
      res => {
        this.orderService.GetOrder();
      },
      err => console.log("error"));


  }
  EditClickOrder(order: Orders): void {
    this.editOrderId = order.orderid;

  }
  UpdateClickOrder(i: number) {

  }

}
