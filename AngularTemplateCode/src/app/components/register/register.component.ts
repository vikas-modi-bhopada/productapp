import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/service/user.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  
  
 // user:User
  constructor(private userService:UserService, private router: Router) {
    console.log("This is register component");
   // this.user = new User()
   }

  ngOnInit(): void {
   // this.registerUser();
  }
  registerUser(user:User) {

    // this.user.name = "ram";
    // this.user.password = "ram123";
    // this.user.location = "Indore";
    // this.user.email = "ram@gmail.com";
    // this.user.isBlocked=false;
    console.log(user);
    
    this.userService.registerUser(user).subscribe(res=>{
      if(res){
        Swal.fire(
          'User Registration',
          'Registration Success',
          'success'
        )
        
        this.router.navigateByUrl("/login")
        console.log("registration success");
      }else{
        console.log("Registration fail");
        Swal.fire(
          'User Registration',
          'Registration Fail',
          'error'
        )
        
      }
      
      
    })
  }

}
