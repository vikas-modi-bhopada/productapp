import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/service/product.service';

@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent implements OnInit {
  products?: Product[]
  UserName?: string
  constructor(private productService:ProductService, private router:ActivatedRoute) {
    console.log("this is dashboard constructor");
   }

   ngOnInit(): void {
    console.log("this method executes after oninit!!!");
    this.productService.getAllProducts().subscribe(res => {
      
      this.products = res;
      console.log(this.products);
      
    });
    this.router.params.forEach(data => {
      this.UserName = data['UserName']
      console.log(this.UserName);
      
    })
  }

}
