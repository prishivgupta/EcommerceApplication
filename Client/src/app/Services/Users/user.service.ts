import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Product } from 'src/app/Models/Product';
import { User } from 'src/app/Models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  baseUrl: string = "https://localhost:7018/api/User/";

  handleError(error: HttpErrorResponse) {
    if(error.error instanceof ErrorEvent) {
      console.error('An error message occured:', error.error.message);
    } else {
      console.error(error.error)
    }
    return throwError('Something happened, please try again');
  }

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'GetAllUsers').pipe(catchError(this.handleError))
  }

  getUserById(id: number): Observable<any> {
    return this.http.get<any>(this.baseUrl + `GetUserById/${id}`).pipe(catchError(this.handleError))
  }

  addUser(User: User): Observable<any> {
    return this.http.post<any>(this.baseUrl + 'AddUser', User).pipe(catchError(this.handleError))
  }

  updateUser(User: User): Observable<any> {
    return this.http.put<any>(this.baseUrl + 'UpdateUser', User).pipe(catchError(this.handleError))
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete<any>(this.baseUrl + `DeleteUser/${id}`).pipe(catchError(this.handleError))
  }

}


