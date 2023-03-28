import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Category } from 'src/app/Models/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  baseUrl: string = "https://localhost:7287/gateway/Category/";

  handleError(error: HttpErrorResponse) {
    if(error.error instanceof ErrorEvent) {
      console.error('An error message occured:', error.error.message);
    } else {
      console.error(error.error)
    }
    return throwError('Something happened, please try again');
  }

  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.baseUrl + 'GetAllCategories').pipe(catchError(this.handleError))
  }

  getCategoryById(id: number): Observable<any> {
    return this.http.get<any>(this.baseUrl + `GetCategoryById/${id}`).pipe(catchError(this.handleError))
  }

  addCategory(category: Category): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'AddCategory', category).pipe(catchError(this.handleError))
  }

  updateCatgeory(category: Category): Observable<any> {
    return this.http.put<any>(this.baseUrl + 'UpdateCategory', category).pipe(catchError(this.handleError))
  }

  deleteCategory(id: number): Observable<any> {
    return this.http.delete<any>(this.baseUrl + `DeleteCategory/${id}`).pipe(catchError(this.handleError))
  }

}


