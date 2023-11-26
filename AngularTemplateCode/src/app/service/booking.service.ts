import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Booking } from '../models/booking';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  
  
  

  constructor(private httpclient: HttpClient) { }
  AddToCart(booking: Booking):Observable<boolean> {
    console.log(booking);
    
    return this.httpclient.post<boolean>('https://localhost:7184/api/Booking/AddToCart', booking)
  }
  getCartByUserName(UserName: string):Observable<Booking[]> {
    return this.httpclient.get<Booking[]>(`https://localhost:7184/api/Booking/GetCartByUserName?username=${UserName}`)
  }
  
}
