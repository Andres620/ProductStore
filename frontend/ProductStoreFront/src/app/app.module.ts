import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule, routingComponents } from './app-routing.module';
import { AuthGuard } from './guardians/auth.guard';
import { AppComponent } from './app.component';

import { LoadScriptsService } from './services/load-scripts.service';
import { SidebarComponent } from './components/sidebar/sidebar.component';

import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AuthComponent } from './components/auth/auth.component';
import { SignupComponent } from './components/auth/signup/signup.component';
import { CreateProductComponent } from './components/product/create-product/create-product.component';
import { DeleteProductComponent } from './components/product/delete-product/delete-product.component';
import { EditProductComponent } from './components/product/edit-product/edit-product.component';
import { ListProductComponent } from './components/product/list-product/list-product.component';
import { ListOrderComponent } from './components/order/list-order/list-order.component';
import { EditOrderComponent } from './components/order/edit-order/edit-order.component';
import { DeleteOrderComponent } from './components/order/delete-order/delete-order.component';
import { CreateOrderComponent } from './components/order/create-order/create-order.component';

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    routingComponents,
    AuthComponent,
    SignupComponent,
    CreateProductComponent,
    DeleteProductComponent,
    EditProductComponent,
    ListProductComponent,
    ListOrderComponent,
    EditOrderComponent,
    DeleteOrderComponent,
    CreateOrderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    LoadScriptsService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
