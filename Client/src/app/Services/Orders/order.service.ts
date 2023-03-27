import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Order } from 'src/app/Models/Order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  baseUrl: string = "https://localhost:7287/gateway/Order/";

  handleError(error: HttpErrorResponse) {
    if(error.error instanceof ErrorEvent) {
      console.error('An error message occured:', error.error.message);
    } else {
      console.error(error.error)
    }
    return throwError('Something happened, please try again');
  }

  getAllorders(): Observable<Order[]> {
    return this.http.get<Order[]>(this.baseUrl + 'GetAllOrders').pipe(catchError(this.handleError))
  }

  getOrderById(id: number): Observable<any> {
    return this.http.get<any>(this.baseUrl + `GetOrderById/${id}`).pipe(catchError(this.handleError))
  }

  placeOrder(order: Order): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'PlaceOrder', order).pipe(catchError(this.handleError))
  }

  updateOrder(order: Order): Observable<any> {
    return this.http.put<any>(this.baseUrl + 'UpdateOrder', order).pipe(catchError(this.handleError))
  }

  deleteOrder(id: number): Observable<any> {
    return this.http.delete<any>(this.baseUrl + `DeleteOrder/${id}`).pipe(catchError(this.handleError))
  }

}



