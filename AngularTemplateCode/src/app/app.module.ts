import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './components/nav/nav.component';
import { HeaderComponent } from './components/header/header.component';
import { FormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import { AddProductComponent } from './components/add-product/add-product.component';
import { LogoutComponent } from './components/logout/logout.component';
import { DeleteProductComponent } from './components/delete-product/delete-product.component';
import { UpdateProductComponent } from './components/update-product/update-product.component'
import { ReactiveFormsModule  } from '@angular/forms';
import { AdminHeaderComponent } from './components/admin-header/admin-header.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';
import { CartComponent } from './components/cart/cart.component';
import { AddtocartComponent } from './components/addtocart/addtocart.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    DashboardComponent,
    NavComponent,
    HeaderComponent,
    AddProductComponent,
    LogoutComponent,
    DeleteProductComponent,
    UpdateProductComponent,
    AdminHeaderComponent,
    UserDashboardComponent,
    CartComponent,
    AddtocartComponent,
   
    
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    BrowserAnimationsModule,
    FormsModule,
    MatInputModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
