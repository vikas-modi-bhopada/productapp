import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/service/product.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  products?: Product[]
  constructor(private productService:ProductService) {
    console.log("this is dashboard constructor");
   }

  ngOnInit(): void {
    console.log("this method executes after oninit!!!");
    this.productService.getAllProducts().subscribe(res => {
      console.log(res);
      this.products = res;
    });
  }

}
