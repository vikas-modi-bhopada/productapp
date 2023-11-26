import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/service/product.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.css']
})
export class DeleteProductComponent implements OnInit {
  productId = 0;

  constructor(private rout: Router, private productService: ProductService, private router: ActivatedRoute) { }

  ngOnInit(): void {
    this.deleteProduct();
  }
  deleteProduct() {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it !'
    }
    )
      .then((result) => {
        if (result.isConfirmed) {
          this.router.params.subscribe(data => {
            console.log(data['id']);
            
            this.productId = data['id']
            this.productService.deleteProduct(this.productId).subscribe(res => {
              if (res) {
                Swal.fire(
                  'Product Deletion',
                  'Deletion Success',
                  'success'
                )
                this.rout.navigateByUrl("/dashboard")
               
              } else {
                
                Swal.fire(
                  'Product Deletion',
                  'Deletion Fail',
                  'error'
                )

              }


            })
          })
        }
      })
  }

}
