import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { OrderComponentComponent } from './order-component/order-component.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [{
  path: 'Order',
  component: OrderComponentComponent
},
  {
    path: 'Register',
    component: RegisterComponent

  },
  {
    path: 'Login',
    component: LoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
