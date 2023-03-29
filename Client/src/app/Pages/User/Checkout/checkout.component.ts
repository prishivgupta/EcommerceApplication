import { Component } from '@angular/core';
import { CartItem } from 'src/app/Models/CartItem';
import { Order } from 'src/app/Models/Order';
import { CartService } from 'src/app/Services/Cart/cart.service';
import { OrderService } from 'src/app/Services/Orders/order.service';
import { TransactionService } from 'src/app/Services/Transactions/transaction.service';
import { UserService } from 'src/app/Services/Users/user.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent {

  constructor(private cartService: CartService,private orderService: OrderService,private userService: UserService, private transactionService: TransactionService) {}

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
  transaction: any = {
    orderId: 0,
    userName: "",
    userEmail: "",
    shipmentAddress: "",
    paymentMethod: ""
  }

  orderSuccess = false;

  getAllCartItems(): void {
    this.cartService.getAllCartItems(Number(localStorage.getItem('cartId'))).subscribe(cartItems => this.cartItems = cartItems);
  }

  updateCartId(): void {
    this.userService.getUserById(Number(localStorage.getItem('userId'))).subscribe( (user) => {
      localStorage.setItem('cartId', user.cartId) 
      this.orderSuccess = true;
      this.transaction.orderId = this.order.orderId
      this.transaction.userName = user.userName
      this.transaction.userEmail = user.userEmail
      this.transaction.paymentStatus = "Success"
      this.transaction.shipmentAddress = this.order.shipmentAddress
      this.transaction.paymentMethod = this.order.paymentMethod
      this.addTransaction()
    })
  }

  addTransaction(): void {
    this.transactionService.addTransaction(this.transaction).subscribe()
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
