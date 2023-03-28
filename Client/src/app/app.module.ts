import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './Components/Navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginComponent } from './Pages/Auth/login/login.component';
import { RegisterComponent } from './Pages/Auth/register/register.component';
import { AuthInterceptor } from './Interceptors/auth.interceptor';
import { HomeComponent } from './Pages/Admin/Home/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProductsComponent } from './Pages/Admin/Products/Products/products.component';
import { AddProductComponent } from './Pages/Admin/Products/AddProduct/add-product.component';
import { EditProductComponent } from './Pages/Admin/Products/EditProduct/edit-product.component';
import { CategoriesComponent } from './Pages/Admin/Categories/Categories/categories.component';
import { AddCategoryComponent } from './Pages/Admin/Categories/AddCategory/add-category.component';
import { EditCategoryComponent } from './Pages/Admin/Categories/EditCategory/edit-category.component';
import { OrdersComponent } from './Pages/Admin/Orders/Orders/orders.component';
import { EditOrderComponent } from './Pages/Admin/Orders/EditOrder/edit-order.component';
import { UsersComponent } from './Pages/Admin/Users/Users/users.component';
import { AddUserComponent } from './Pages/Admin/Users/AddUser/add-user.component';
import { EditUserComponent } from './Pages/Admin/Users/EditUser/edit-user.component';
import { TransactionsComponent } from './Pages/Admin/Transactions/Transactions/transactions.component';
import { EditTransactionComponent } from './Pages/Admin/Transactions/EditTransaction/edit-transaction.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    ProductsComponent,
    AddProductComponent,
    EditProductComponent,
    CategoriesComponent,
    AddCategoryComponent,
    EditCategoryComponent,
    OrdersComponent,
    EditOrderComponent,
    UsersComponent,
    AddUserComponent,
    EditUserComponent,
    TransactionsComponent,
    EditTransactionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
  ],
  providers: [{provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
