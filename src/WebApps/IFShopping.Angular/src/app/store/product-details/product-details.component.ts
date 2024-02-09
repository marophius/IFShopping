import { Component, Input, OnDestroy, OnInit, inject } from '@angular/core';
import { IProduct } from '../../shared/models/product';
import { StoreService } from '../store.service';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subscription, concatMap, map, shareReplay, tap } from 'rxjs';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss'
})
export class ProductDetailsComponent implements OnInit, OnDestroy {
  private storeService: StoreService = inject(StoreService);
  private activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  private basketService: BasketService = inject(BasketService);
  public product$: Observable<IProduct> = this.activatedRoute.params.pipe(
    concatMap(params => this.storeService.getProductById(params["id"])),
    tap({
      next: (res: IProduct) => this.bcService.set('@productDetails', res.name),
      error: (error: Error) => console.log(error)
    })
  );
  private bcService: BreadcrumbService = inject(BreadcrumbService);
  public quantity: number = 1;
  public subscription!: Subscription;

  ngOnInit(): void {
    
  }

  addItemToCart(product: IProduct){
    if(product){
      this.subscription = this.basketService.addItemToBasket(product, this.quantity);
    }
  }

  incrementQuantity(){
    this.quantity++;
  }

  decrementQuantity(){
    if(this.quantity>1){
      this.quantity--;
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
