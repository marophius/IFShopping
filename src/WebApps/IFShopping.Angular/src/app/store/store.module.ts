import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreComponent } from './store.component';
import { ProductItemsComponent } from './product-items/product-items.component';
import { SharedModule } from '../shared/shared.module';
import { StoreRoutingModule } from './store-routing.module';
import { ProductDetailsComponent } from './product-details/product-details.component';



@NgModule({
  declarations: [
    StoreComponent,
    ProductItemsComponent,
    ProductDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    StoreRoutingModule
  ],
  exports: [
    StoreComponent,
    ProductItemsComponent
  ]
})
export class StoreModule { }
