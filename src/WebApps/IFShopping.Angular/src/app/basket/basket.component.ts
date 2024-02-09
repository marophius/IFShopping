import { Component, OnDestroy, inject } from '@angular/core';
import { BasketService } from './basket.service';
import { Observable, Subscription } from 'rxjs';
import { Basket, IBasketItem } from '../shared/models/basket';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.scss'
})
export class BasketComponent implements OnDestroy {
  private basketService: BasketService = inject(BasketService);
  public basketSource$: Observable<Basket> = this.basketService.basketSource$;
  private incrementSubscription!: Subscription;
  private decrementSubscription!: Subscription;
  public removeItemSubscription!: Subscription;


  removeBasketItem(item: IBasketItem){
    this.removeItemSubscription = this.basketService.removeItemFromBasket(item)!.subscribe();
  }

  incrementItem(item: IBasketItem){
    this.incrementSubscription = this.basketService.incrementItemQuantity(item)!.subscribe();
  }

  decrementItem(item: IBasketItem){
    this.decrementSubscription = this.basketService.decrementItemQuantity(item)!.subscribe();
  }

  ngOnDestroy(): void {
    this.removeItemSubscription?.unsubscribe();
    this.incrementSubscription?.unsubscribe();
    this.decrementSubscription?.unsubscribe();
  }
}
