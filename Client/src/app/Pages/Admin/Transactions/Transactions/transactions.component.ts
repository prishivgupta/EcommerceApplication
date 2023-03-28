import { Component } from '@angular/core';
import { Transaction } from 'src/app/Models/Transaction';
import { TransactionService } from 'src/app/Services/Transactions/transaction.service';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent {

  constructor(private transactionService: TransactionService) {}

  transactions: Transaction[] = [];
  id?: string;
  

  getAllTransactions(): void {
    this.transactionService.getAllTransactions().subscribe(transactions => this.transactions = transactions);
  }

  deleteTransaction(id: string): void {
    this.transactionService.deleteTransaction(id).subscribe(() => this.getAllTransactions());
  }

  ngOnInit(): void {
    this.getAllTransactions();
  }

}

