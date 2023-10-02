import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrderComponentComponent } from './order-component/order-component.component';
import { AddOrderComponent } from './add-order/add-order.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { DisableContorlDirective } from './disable-contorl.directive';


@NgModule({
  declarations: [
    AppComponent,
    OrderComponentComponent,
    AddOrderComponent,
    RegisterComponent,
    LoginComponent,
    DisableContorlDirective,
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
