import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { AddProductComponent } from './components/add-product/add-product.component';
import { AddtocartComponent } from './components/addtocart/addtocart.component';
import { AdminHeaderComponent } from './components/admin-header/admin-header.component';
import { CartComponent } from './components/cart/cart.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DeleteProductComponent } from './components/delete-product/delete-product.component';
import { HeaderComponent } from './components/header/header.component';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { RegisterComponent } from './components/register/register.component';
import { UpdateProductComponent } from './components/update-product/update-product.component';
import { UserDashboardComponent } from './components/user-dashboard/user-dashboard.component';

const routes: Routes = [
  {path: '',component:HeaderComponent},
  {
    path:'register',component:RegisterComponent
  },
  
  {path:'cart/:UserName',component:CartComponent},
  {path:'dashboard/:UserName',component:UserDashboardComponent},
  {path: 'addtocart/:UserName/:Id',component:AddtocartComponent},
  {path: 'header', component:HeaderComponent},
  {path:'login',component:LoginComponent},
  {path:'dashboard',component:DashboardComponent, canActivate:[AuthGuard]},
  {path: 'addProduct',component:AddProductComponent},
  {path: 'logout',component:LogoutComponent},
  {path: 'deleteProduct/:id', component:DeleteProductComponent},
  {path: 'updateProduct/:id', component:UpdateProductComponent},
  {path: 'userDashboard', component:UserDashboardComponent},
  {path: 'adminHeader', component:AdminHeaderComponent}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
