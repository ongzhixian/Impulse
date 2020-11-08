import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'demo-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  loginForm = new FormGroup({
    login_email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(128)]),
    login_password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.maxLength(128)]),
  });

  constructor() { 
  }

  ngOnInit() {
  }

  onSubmit() {
    // TODO: Use EventEmitter with form value
    console.warn(this.loginForm.value);
  }

}
