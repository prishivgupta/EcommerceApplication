import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { OrderService } from 'src/app/Services/Orders/order.service';
import { Order } from 'src/app/Models/Order';

@Component({
  selector: 'app-edit-order',
  templateUrl: './edit-order.component.html',
  styleUrls: ['./edit-order.component.css']
})
export class EditOrderComponent {

  constructor(private orderService: OrderService, private location: Location, private route: ActivatedRoute) {}

  order: Order = {
    orderId: 0,
    cartId: 0,
    userId: 0,
    shipmentAddress: '',
    orderStatus: '',
    paymentMethod: ''
  };

  goBack(): void {
    this.location.back();
  }

  editOrder(order: Order): void {
    this.orderService.updateOrder(order).subscribe(() => this.goBack());
  }

  getOrderById(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.orderService.getOrderById(id).subscribe(order => {
      this.order.orderId = order.orderId,
      this.order.userId = order.userId,
      this.order.cartId = order.cartId,
      this.order.shipmentAddress = order.shipmentAddress,
      this.order.orderStatus = order.orderStatus,
      this.order.paymentMethod = order.paymentMethod
    });
  }

  ngOnInit(): void {
    this.getOrderById()
  }

}

