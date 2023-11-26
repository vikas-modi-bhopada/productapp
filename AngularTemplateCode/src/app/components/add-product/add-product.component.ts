import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/service/product.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  constructor(private productService: ProductService, private router:Router) { }

  ngOnInit(): void {
  }
  addProduct(product: Product) {
    console.log(product);
    this.productService.addProduct(product).subscribe(res => {
      if (res) {
        Swal.fire(
          'Add Product',
          'Product Added Successfully',
          'success'
        )
        this.router.navigateByUrl("/dashboard")
        console.log("Product Added");
      } else {
        Swal.fire(
          'Add Product',
          'Product Fail',
          'error'
        )
        console.log("Fail");

      }


    })
  }

}
