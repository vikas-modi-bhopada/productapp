import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  
  
  
  constructor(private httpclient: HttpClient) { }
  getAllProducts(): Observable<Product[]> {
    return this.httpclient.get<Product[]>('https://localhost:7083/api/Product/GetAllProduct');
  }

  addProduct(product: Product): Observable<boolean> {
    return this.httpclient.post<boolean>('https://localhost:7083/api/Product/AddProduct', product)
  }
  deleteProduct(productId: number):Observable<boolean> {
    return this.httpclient.delete<boolean>(`https://localhost:7083/api/Product/DeleteProduct?id=${productId}`)
  }
  getProductById(productId:number):Observable<Product> {
    return this.httpclient.get<Product>(`https://localhost:7083/api/Product/GetProductById/${productId}`);
  }
  updateProduct(id: number, product: Product):Observable<boolean> {
    return this.httpclient.put<boolean>(`https://localhost:7083/api/Product/UpdateProduct/${id}`, product);
  }
}
