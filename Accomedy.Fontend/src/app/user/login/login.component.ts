
import { Router, ActivatedRoute } from '@angular/router';
import { UserRegister } from './../models/UserRegister';
import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  isLoginError : boolean = false;
  loginResult : any;
  constructor(private _userService : UserService , private route : Router ,private activatedroute:ActivatedRoute) { }

  ngOnInit(): void {
  }

  onLoginSubmit(username,password){
    this._userService.checkLogin(username,password).subscribe((data :any)=>{
      if (data== true ) {
        localStorage.setItem('userToken',data.access_token);
        console.log(data);
        this.route.navigate(['/post-list']);
      }  
      if (data == false) {      
          this.isLoginError = true;
        this.route.navigate(['/login']);
      }
    },
    
    );
    
    // if (this.isLoginError == false) {
    //     localStorage.setItem
    //     console.log('username : '+ username, 'password : '+ password);
    //     this.route.navigate(['/post-list']);
    // }else{
    //     this.route.navigate(['/register'])
    // }
}
}
