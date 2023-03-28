import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Transaction } from 'src/app/Models/Transaction';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  constructor(private http: HttpClient) { }

  baseUrl: string = "https://localhost:7040/api/Transactions/";

  handleError(error: HttpErrorResponse) {
    if(error.error instanceof ErrorEvent) {
      console.error('An error message occured:', error.error.message);
    } else {
      console.error(error.error)
    }
    return throwError('Something happened, please try again');
  }

  getAllTransactions(): Observable<Transaction[]> {
    return this.http.get<Transaction[]>(this.baseUrl + 'GetAllTransactions').pipe(catchError(this.handleError))
  }

  getTransactionById(id: string): Observable<any> {
    return this.http.get<any>(this.baseUrl + `GetTransactionById/${id}`).pipe(catchError(this.handleError))
  }

  updateTransaction(transaction: Transaction): Observable<any> {
    return this.http.put<any>(this.baseUrl + `UpdateTransaction/${transaction._id}`, transaction).pipe(catchError(this.handleError))
  }

  deleteTransaction(id: string): Observable<any> {
    return this.http.delete<any>(this.baseUrl + `DeleteTransaction/${id}`).pipe(catchError(this.handleError))
  }

}