import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { ListUserComponent } from './components/user/list-user/list-user.component';
import { CreateUserComponent } from './components/user/create-user/create-user.component';
import { EditUserComponent } from './components/user/edit-user/edit-user.component';
import { DeleteUserComponent } from './components/user/delete-user/delete-user.component';
import { AuthComponent } from './components/auth/auth.component';
import { ListProductComponent } from './components/product/list-product/list-product.component';
import { CreateProductComponent } from './components/product/create-product/create-product.component';
import { EditProductComponent } from './components/product/edit-product/edit-product.component';
import { DeleteProductComponent } from './components/product/delete-product/delete-product.component';
import { ListOrderComponent } from './components/order/list-order/list-order.component';
import { CreateOrderComponent } from './components/order/create-order/create-order.component';
import { EditOrderComponent } from './components/order/edit-order/edit-order.component';
import { DeleteOrderComponent } from './components/order/delete-order/delete-order.component';
import { AuthGuard } from './guardians/auth.guard';

const routes: Routes = [
  { path: '', component: AuthComponent},
  { path: 'auth', component: AuthComponent},
  { path: 'list-users', component: ListUserComponent, canActivate: [AuthGuard]},
  { path: 'create-user', component: CreateUserComponent, canActivate: [AuthGuard]},
  { path: 'edit-user/:id', component: EditUserComponent, canActivate: [AuthGuard]},
  { path: 'delete-user/:id', component: DeleteUserComponent, canActivate: [AuthGuard]},
  { path: 'list-products', component: ListProductComponent, canActivate: [AuthGuard]},
  { path: 'create-product', component: CreateProductComponent, canActivate: [AuthGuard]},
  { path: 'edit-product/:id', component: EditProductComponent, canActivate: [AuthGuard]},
  { path: 'delete-product/:id', component: DeleteProductComponent, canActivate: [AuthGuard]},
  { path: 'list-orders', component: ListOrderComponent, canActivate: [AuthGuard]},
  { path: 'create-order', component: CreateOrderComponent, canActivate: [AuthGuard]},
  { path: 'edit-order/:id', component: EditOrderComponent, canActivate: [AuthGuard]},
  { path: 'delete-order/:id', component: DeleteOrderComponent, canActivate: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [
    LoginComponent,
    ListUserComponent,
    CreateUserComponent,
    EditUserComponent,
    DeleteUserComponent,
    AuthComponent,
    ListProductComponent,
    CreateProductComponent,
    EditProductComponent,
    DeleteProductComponent,
    ListOrderComponent,
    CreateOrderComponent,
    EditOrderComponent,
    DeleteOrderComponent
]