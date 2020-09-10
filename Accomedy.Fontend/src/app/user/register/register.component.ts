
import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from './../services/user.service';
import { error } from '@angular/compiler/src/util';
import { UserRegister } from './../models/UserRegister';
import { FormGroup, FormControl, Validators} from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  form : FormGroup;

  user: UserRegister = new UserRegister();
  RegisterError: any;



  constructor(private _userService: UserService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {

    this.form = new FormGroup({
      seru_name: new FormControl('', [Validators.required, Validators.minLength(3)]),
      email: new FormControl('', [Validators.required, Validators.email]),
    });

    this.RegisterError = false;
  }

  OnRegisterSubmit(user) {
    console.log(user);
    this._userService.register(user)
      .subscribe
      (
        data => { 
         this.RegisterError = !data;
         if (this.RegisterError == false) {  
           console.log(data);

          return this.router.navigate(['post-list']);
         }
        }
      );
  }

  
 
}








