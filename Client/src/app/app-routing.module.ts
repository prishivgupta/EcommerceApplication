import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './Guard/auth.guard';
import { AddCategoryComponent } from './Pages/Admin/Categories/AddCategory/add-category.component';
import { CategoriesComponent } from './Pages/Admin/Categories/Categories/categories.component';
import { EditCategoryComponent } from './Pages/Admin/Categories/EditCategory/edit-category.component';
import { EditOrderComponent } from './Pages/Admin/Orders/EditOrder/edit-order.component';
import { OrdersComponent } from './Pages/Admin/Orders/Orders/orders.component';
import { AddProductComponent } from './Pages/Admin/Products/AddProduct/add-product.component';
import { EditProductComponent } from './Pages/Admin/Products/EditProduct/edit-product.component';
import { ProductsComponent } from './Pages/Admin/Products/Products/products.component';
import { EditTransactionComponent } from './Pages/Admin/Transactions/EditTransaction/edit-transaction.component';
import { TransactionsComponent } from './Pages/Admin/Transactions/Transactions/transactions.component';
import { AddUserComponent } from './Pages/Admin/Users/AddUser/add-user.component';
import { EditUserComponent } from './Pages/Admin/Users/EditUser/edit-user.component';
import { UsersComponent } from './Pages/Admin/Users/Users/users.component';
import { LoginComponent } from './Pages/Auth/Login/login.component';
import { RegisterComponent } from './Pages/Auth/Register/register.component';
import { CartComponent } from './Pages/User/Cart/cart.component';
import { CheckoutComponent } from './Pages/User/Checkout/checkout.component';
import { HomeComponent } from './Pages/User/Home/home.component';
import { ProductComponent } from './Pages/User/Product/product.component';

const routes: Routes = [
  { path:'', redirectTo:'users', pathMatch:'full' },
  { path:'login', component: LoginComponent, pathMatch:'full' },
  { path:'register', component: RegisterComponent, pathMatch:'full' },
  { path:'categories', component: CategoriesComponent, canActivate: [AuthGuard], pathMatch:'full' },
  { path:'categories/addCategory', component: AddCategoryComponent, canActivate: [AuthGuard], pathMatch:'full' },
  { path:'categories/updateCategory/:id', component: EditCategoryComponent, canActivate: [AuthGuard], pathMatch:'full' },
  { path:'users', component: UsersComponent, canActivate: [AuthGuard], pathMatch:'full' },
  { path:'users/addUser', component: AddUserComponent, canActivate: [AuthGuard], pathMatch:'full' },
  { path:'users/updateUser/:id', component: EditUserComponent, canActivate: [AuthGuard], pathMatch:'full' },
  { path:'orders', component: OrdersComponent , canActivate: [AuthGuard], pathMatch:'full' },
  { path:'orders/updateOrder/:id', component: EditOrderComponent, canActivate: [AuthGuard], pathMatch:'full' },
  { path:'products', component: ProductsComponent, canActivate: [AuthGuard], pathMatch:'full' },
  { path:'products/addProduct', component: AddProductComponent, canActivate: [AuthGuard], pathMatch:'full' },
  { path:'products/updateProduct/:id', component: EditProductComponent, canActivate: [AuthGuard], pathMatch:'full' },
  { path:'transactions', component: TransactionsComponent , canActivate: [AuthGuard], pathMatch:'full' },
  { path:'transactions/updateTransaction/:id', component: EditTransactionComponent, canActivate: [AuthGuard], pathMatch:'full' },
  { path:'home', component: HomeComponent, pathMatch:'full' },
  { path:'product/:id', component: ProductComponent, pathMatch:'full' },
  { path:'cart', component: CartComponent, pathMatch:'full' },
  { path:'checkout', component: CheckoutComponent, pathMatch:'full' },
  { path:'**', redirectTo:'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
