import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from '../Models/login';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  LoginForm: FormGroup;
  isLoginFormSubmitted: boolean = false;

  constructor(private accountservice: AccountService, private router: Router) {
    this.LoginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),



    });

  }
  
  get login_emailControl(): any {
    return this.LoginForm.controls["email"]
  }
  get login_passwordControl(): any {
    return this.LoginForm.controls["password"]
  }


  ngOnInit(): void {
  }
  LoginSubmitted() {
    this.isLoginFormSubmitted = true;
    this.accountservice.PostLogin(this.LoginForm.value).subscribe({

      next: (response: any) => {
        console.log(response)
        this.isLoginFormSubmitted = false;
        localStorage["token"] = response.token;
        this.router.navigate(['/Order']);
        this.LoginForm.reset();
      },

      error: () => {
        console.log(Error);
      },

      complete: () => { },


    })
  }

}
