import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Booking } from 'src/app/models/booking';
import { BookingService } from 'src/app/service/booking.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  booking?: Booking[]
  UserName = ""


  constructor(private bookingService: BookingService, private router: ActivatedRoute) {

  }


  ngOnInit(): void {
    this.router.params.forEach(data => {
      this.UserName = data['UserName']
      console.log(this.UserName);
      this.bookingService.getCartByUserName(this.UserName).subscribe(res => {
        //console.log(res);
        this.booking = res;
        console.log(this.booking);
        

      });
  
      
    })
    
  }

}
