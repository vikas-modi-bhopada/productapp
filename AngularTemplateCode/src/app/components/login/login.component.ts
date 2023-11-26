import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginUser } from 'src/app/models/login-user';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/service/user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private userService: UserService, private router: Router) {
    console.log("Inside log in method");

  }

  ngOnInit(): void {

  }
  login(loginUser: LoginUser) {

    this.userService.login(loginUser).subscribe({
      next: (res) => {
        console.log(res);
        if (loginUser.Name == "admin@gmail.com" && loginUser.password == "admin")
          this.router.navigateByUrl("/adminHeader")
        else
          this.router.navigateByUrl(`/dashboard/${loginUser.Name}`);
        let jsonObject = JSON.stringify(res);
        let jsonToken = JSON.parse(jsonObject)
        console.log('User Token After Login :::: ${jsonToken["Token]}');
        localStorage.setItem('userToken', jsonToken["Token"]);
      },
      error: (e) => {
        console.error(e);
        Swal.fire({
          icon: 'error',
          title: 'error',
          text: `${e.error.text}`
        }


        )

      }
    })

    // this.userService.login(loginUser).subscribe(res => {
    //   console.log(res);
    //   if(loginUser.Name == "vikash" && loginUser.password == "vikash")
    //   this.router.navigateByUrl("/adminHeader")
    //   else
    //   this.router.navigateByUrl("/userDashboard")
    //   let jsonObject = JSON.stringify(res);
    //   let jsonToken = JSON.parse(jsonObject)
    //   console.log('User Token After Login :::: ${jsonToken["Token]}');
    //   localStorage.setItem('userToken', jsonToken["Token"]);
    // })






  }

}
