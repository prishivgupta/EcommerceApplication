import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './Guard/auth.guard';
import { AddCategoryComponent } from './Pages/Admin/Categories/AddCategory/add-category.component';
import { CategoriesComponent } from './Pages/Admin/Categories/Categories/categories.component';
import { EditCategoryComponent } from './Pages/Admin/Categories/EditCategory/edit-category.component';
import { HomeComponent } from './Pages/Admin/Home/home/home.component';
import { EditOrderComponent } from './Pages/Admin/Orders/EditOrder/edit-order.component';
import { OrdersComponent } from './Pages/Admin/Orders/Orders/orders.component';
import { AddProductComponent } from './Pages/Admin/Products/AddProduct/add-product.component';
import { EditProductComponent } from './Pages/Admin/Products/EditProduct/edit-product.component';
import { ProductsComponent } from './Pages/Admin/Products/Products/products.component';
import { AddUserComponent } from './Pages/Admin/Users/AddUser/add-user.component';
import { EditUserComponent } from './Pages/Admin/Users/EditUser/edit-user.component';
import { UsersComponent } from './Pages/Admin/Users/Users/users.component';
import { LoginComponent } from './Pages/Auth/login/login.component';
import { RegisterComponent } from './Pages/Auth/register/register.component';

const routes: Routes = [
  { path:'', redirectTo:'admin', pathMatch:'full' },
  { path:'login', component: LoginComponent },
  { path:'register', component: RegisterComponent },
  { path:'admin', component: HomeComponent },
  { path:'categories', component: CategoriesComponent, canActivate: [AuthGuard] },
  { path:'categories/addCategory', component: AddCategoryComponent, canActivate: [AuthGuard] },
  { path:'categories/updateCategory/:id', component: EditCategoryComponent, canActivate: [AuthGuard] },
  { path:'users', component: UsersComponent, canActivate: [AuthGuard] },
  { path:'users/addUser', component: AddUserComponent, canActivate: [AuthGuard] },
  { path:'users/updateUser/:id', component: EditUserComponent, canActivate: [AuthGuard] },
  { path:'orders', component: OrdersComponent , canActivate: [AuthGuard] },
  { path:'orders/updateOrder/:id', component: EditOrderComponent, canActivate: [AuthGuard] },
  { path:'products', component: ProductsComponent, canActivate: [AuthGuard] },
  { path:'products/addProduct', component: AddProductComponent, canActivate: [AuthGuard] },
  { path:'products/updateProduct/:id', component: EditProductComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }