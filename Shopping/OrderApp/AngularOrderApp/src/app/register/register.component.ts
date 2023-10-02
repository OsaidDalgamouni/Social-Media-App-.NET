import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterUser } from '../Models/register-user';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  RegisterForm: FormGroup;
  isRegisterdFormSubmitted: boolean = false;

  constructor(private accountservice: AccountService, private router: Router) {
    this.RegisterForm = new FormGroup({
      username: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required,Validators.email]),
      password : new FormControl('', [Validators.required]),
     


    });

  }
  get register_usernameControl(): any {
    return this.RegisterForm.controls["username"]
  }
  get register_emailControl(): any {
    return this.RegisterForm.controls["email"]
  }
  get register_passwordControl(): any {
    return this.RegisterForm.controls["password"]
  }
  

  ngOnInit(): void {
  }
  RegisterSubmitted() {
    this.isRegisterdFormSubmitted = true;
    this.accountservice.PostRegister(this.RegisterForm.value).subscribe({

      next: (response: RegisterUser) => {
        console.log(response)
        this.isRegisterdFormSubmitted = false;
        this.router.navigate(['/Order']);
        this.RegisterForm.reset();
      },

      error: () => {
        console.log(Error);
      },

      complete: () => {},


    })
  }
}
