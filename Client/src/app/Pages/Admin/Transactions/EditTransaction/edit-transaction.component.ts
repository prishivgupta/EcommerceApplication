import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { TransactionService } from 'src/app/Services/Transactions/transaction.service';
import { Transaction } from 'src/app/Models/Transaction';

@Component({
  selector: 'app-edit-transaction',
  templateUrl: './edit-transaction.component.html',
  styleUrls: ['./edit-transaction.component.css']
})
export class EditTransactionComponent {

  constructor(private transactionService: TransactionService, private location: Location, private route: ActivatedRoute) {}

  transaction: Transaction = {
    id: '',
    userName: '',
    userEmail: '',
    shipmentAddress: '',
    paymentMethod: '',
    paymentStatus: ''
  };

  goBack(): void {
    this.location.back();
  }

  editTransaction(transaction: Transaction): void {
    this.transactionService.updateTransaction(transaction).subscribe(() => this.goBack());
  }

  getTransactionById(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));
    this.transactionService.getTransactionById(id).subscribe(transaction => {
      this.transaction.id = transaction.id,
      this.transaction.userName = transaction.userName,
      this.transaction.userEmail = transaction.userEmail,
      this.transaction.shipmentAddress = transaction.shipmentAddress,
      this.transaction.paymentMethod = transaction.paymentMethod,
      this.transaction.paymentStatus = transaction.paymentStatus
    });
  }

  ngOnInit(): void {
    this.getTransactionById()
  }

}
