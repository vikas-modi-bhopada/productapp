import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/service/product.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css']
})
export class UpdateProductComponent implements OnInit {
  productId = 0

  edit = new FormGroup(
    {
      name: new FormControl(),
      description: new FormControl(),
      price: new FormControl(),
      imgPath: new FormControl()
    }
  )
  product: Product
  constructor(private productService: ProductService, private _Activatedroute: ActivatedRoute, private router: Router) {
    this.product = new Product()

  }

  ngOnInit(): void {
    this.GetProductById();
  }
  GetProductById() {
    this._Activatedroute.params.subscribe(result => {
      this.productId = result['id']
      this.productService.getProductById(this.productId).subscribe(res => {

        this.edit = new FormGroup(
          {
            name: new FormControl(res['name']),
            description: new FormControl(res['description']),
            price: new FormControl(res['price']),
            imgPath: new FormControl(res['imgPath'])
          }
        )



      });
    })

  }
  updateProduct(product: Product) {
    this.productService.updateProduct(this.productId, product).subscribe(res => {
      if (res) {
        Swal.fire(
          'Update Product',
          'Product Update Successfully',
          'success'
        )
        this.router.navigateByUrl("/dashboard")

      } else {
        Swal.fire(
          'Update Product',
          'Product Fail',
          'error'
        )


      }

    })

  }
}
