import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { CartItem } from 'src/app/Models/CartItem';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private http: HttpClient) { }

  baseUrl: string = "https://localhost:7019/api/Cart/";

  handleError(error: HttpErrorResponse) {
    if(error.error instanceof ErrorEvent) {
      console.error('An error message occured:', error.error.message);
    } else {
      console.error(error.error)
    }
    return throwError('Something happened, please try again');
  }

  getAllCartItems(cartId: number): Observable<CartItem[]> {
    return this.http.get<CartItem[]>(this.baseUrl + `GetAllCartItems/${cartId}`).pipe(catchError(this.handleError))
  }

  addToCart(cartItem: CartItem): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'AddToCart', cartItem).pipe(catchError(this.handleError))
  }

  clearCart(cartId: number): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'ClearCart', cartId).pipe(catchError(this.handleError))
  }

}