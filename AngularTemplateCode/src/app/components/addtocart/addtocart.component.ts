import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookingService } from 'src/app/service/booking.service';
import { ProductService } from 'src/app/service/product.service';
import { Booking } from 'src/app/models/booking';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-addtocart',
  templateUrl: './addtocart.component.html',
  styleUrls: ['./addtocart.component.css']
})
export class AddtocartComponent implements OnInit {
UserName ?: string
productId = 0
booking : Booking
  constructor(private route:ActivatedRoute, private bookingService : BookingService, private productService : ProductService) { 
    this.booking = new Booking();
  }

  ngOnInit(): void {
    this.route.params.forEach(data => {

      this.UserName = data['UserName'];
      this.productId = data['Id']
      
      this.AddToCart()
      
      
    })
  }
  AddToCart()
  {
      this.productService.getProductById(this.productId).subscribe(res => {        
      this.booking.userName = this.UserName
      this.booking.productId = this.productId
      this.booking.name = res['name']
      this.booking.description = res['description']      
      //this.booking.Price = res['price']
      this.booking.price = res['price']
      this.booking.imgPath = res['imgPath']
      console.log(this.booking)            
      console.log("Before Cart");
      this.bookingService.AddToCart(this.booking).subscribe(res1 => {
        if(res1){
          Swal.fire(
            'Product Added To Cart',
            'Success',
            'success'
          )
          
        }
      })
    })

  }

}
