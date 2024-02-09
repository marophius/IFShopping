import { Component, OnDestroy, OnInit, inject, signal } from '@angular/core';
import { BasketService } from './basket/basket.service';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit, OnDestroy {
  title = 'IFShopping.Angular';
  public basketService: BasketService = inject(BasketService);
  private localStorage: StorageService = inject(LOCAL_STORAGE);
  private subscription!: Subscription;

  ngOnInit(): void {
    const basket_username = this.localStorage.get('basket_username');
    if(basket_username){
      this.subscription = this.basketService.getBasket(basket_username).subscribe();
    }  
  }


  ngOnDestroy(): void {
      this.subscription?.unsubscribe();
  }
}
