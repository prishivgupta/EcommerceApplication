import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Product } from 'src/app/Models/Product';
import { CartItem } from 'src/app/Models/CartItem';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  baseUrl: string = "https://localhost:7287/gateway/Product/";

  handleError(error: HttpErrorResponse) {
    if(error.error instanceof ErrorEvent) {
      console.error('An error message occured:', error.error.message);
    } else {
      console.error(error.error)
    }
    return throwError('Something happened, please try again');
  }

  getAllProducts(categoryId?: number, search?: string ): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseUrl + `GetAllProducts?search=${search}`).pipe(catchError(this.handleError))
  }

  getProductById(id: number): Observable<any> {
    return this.http.get<any>(this.baseUrl + `GetProductById/${id}`).pipe(catchError(this.handleError))
  }

  addProduct(product: Product): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'AddProduct', product).pipe(catchError(this.handleError))
  }

  updateProduct(product: Product): Observable<any> {
    return this.http.put<any>(this.baseUrl + 'UpdateProduct', product).pipe(catchError(this.handleError))
  }

  deleteProduct(id: number): Observable<any> {
    return this.http.delete<any>(this.baseUrl + `DeleteProduct/${id}`).pipe(catchError(this.handleError))
  }

}

