import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { StoreComponent } from './store.component';


const routes:Routes = [
  {path:'', component: StoreComponent},
  //{path:':id', component: ProductDetailsComponent, data:{breadcrumb:{alias:'productDetails'}}}
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    //RouterModule.forChild(routes)
  ],
  exports: [
    //RouterModule
  ]
})
export class StoreRoutingModule { }
