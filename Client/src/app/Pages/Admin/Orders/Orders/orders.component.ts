import { Component } from '@angular/core';
import { Order } from 'src/app/Models/Order';
import { OrderService } from 'src/app/Services/Orders/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent {

  constructor(private orderService: OrderService) {}

  orders: Order[] = [];
  id?: number;
  

  getAllOrders(): void {
    this.orderService.getAllorders().subscribe(orders => this.orders = orders);
  }

  deleteOrder(id: number): void {
    this.orderService.deleteOrder(id).subscribe(() => this.getAllOrders());
  }

  ngOnInit(): void {
    this.getAllOrders();
  }

}

