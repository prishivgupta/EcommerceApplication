import { Component } from '@angular/core';
import { CartItem } from 'src/app/Models/CartItem';
import { Order } from 'src/app/Models/Order';
import { CartService } from 'src/app/Services/Cart/cart.service';
import { OrderService } from 'src/app/Services/Orders/order.service';
import { UserService } from 'src/app/Services/Users/user.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {

  constructor(private cartService: CartService,private orderService: OrderService,private userService: UserService) {}

  cartItems: CartItem[] = [];

  order: Order = {
    orderId: 0,
    cartId: 0,
    userId: 0,
    shipmentAddress: '',
    orderStatus: '',
    paymentMethod: ''
  }

  address: any = {
    address: '',
    state: '',
    city: '',
    pincode: ''
  }

  orderSuccess = false;

  getAllCartItems(): void {
    this.cartService.getAllCartItems(Number(localStorage.getItem('cartId'))).subscribe(cartItems => this.cartItems = cartItems);
  }

  updateCartId(): void {
    this.userService.getUserById(Number(localStorage.getItem('userId'))).subscribe( (user) => {
      localStorage.setItem('cartId', user.cartId) 
      this.orderSuccess = true;
    })
  }

  placeOrder(): void {
    this.order.cartId = Number(localStorage.getItem('cartId'))
    this.order.userId = Number(localStorage.getItem('userId'))
    this.order.shipmentAddress = this.address.address + " " + this.address.city + " " + this.address.state + " " + this.address.pincode
    this.order.orderStatus = "Pending"
    this.orderService.placeOrder(this.order).subscribe(() => {
      this.updateCartId();
    });
  }

  ngOnInit(): void {
    this.getAllCartItems();
  }
}
