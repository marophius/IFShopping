import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable, catchError, tap, throwError } from 'rxjs';
import { Basket, IBasket, IBasketItem } from '../shared/models/basket';
import { IProduct } from '../shared/models/product';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  private readonly baseURL:string = 'http://localhost:9010/';
  private basketSource: BehaviorSubject<Basket> = new BehaviorSubject<Basket>(new Basket());
  public basketSource$: Observable<Basket> = this.basketSource.asObservable();
  
  constructor(
    private http: HttpClient,
    @Inject(LOCAL_STORAGE) private localStorage:StorageService
  ) { }

  public getBasket(userName: string): Observable<IBasket> {
    return this.http.get<IBasket>(this.baseURL + 'Basket/GetBasket/' + userName).pipe(
      tap({
        next: (basket) => {
          let newBasket = new Basket()
          newBasket = basket
          this.basketSource.next(newBasket)
        }
      }),
      catchError((error: Error) => {
        return  throwError(error)
      })
    );
  }

  public setBasket(basket: IBasket) {
    return this.http.post<IBasket>(this.baseURL + 'Basket/CreateBasket', basket).pipe(
      tap({
        next: (basket: IBasket) => {
          let newBasket = new Basket();
          newBasket = basket
          this.basketSource.next(newBasket)
        },
        error: (error: HttpErrorResponse) => {
          this.localStorage.remove('basket_username');
          return throwError(error);
        }
      })
    );
  }

  public addItemToBasket(item: IProduct, quantity: number = 1) {
    const itemToAdd: IBasketItem = this.mapProductItemToBasketItem(item);
    const basket:IBasket = this.basketSource.value;
    this.localStorage.set('basket_username', 'icaro');
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    console.log(basket);
    return this.setBasket(basket).subscribe()
  }

  incrementItemQuantity(item: IBasketItem){
    const basket = this.basketSource.value;
    if(!basket) return this.setBasket(new Basket());
    const founItemIndex = basket.items.findIndex((x)=>x.productId === item.productId);
    basket.items[founItemIndex].quantity++;
    return this.setBasket(basket);
  }

  decrementItemQuantity(item: IBasketItem){
    const basket = this.basketSource.value;
    if(!basket) return this.setBasket(new Basket());
    const founItemIndex = basket.items.findIndex((x)=>x.productId === item.productId);
    if(basket.items[founItemIndex].quantity >1){
      basket.items[founItemIndex].quantity--;
      return this.setBasket(basket);
    }else {
      return this.removeItemFromBasket(item);
    }
  }

  removeItemFromBasket(item:IBasketItem){
    const basket = this.basketSource.value;
    if(!basket) return this.setBasket(new Basket());
    if(basket.items.some((x) =>x.productId ===item.productId)){
      basket.items = basket.items.filter((x)=>x.productId!== item.productId)
      if(basket.items.length>0){
       return this.setBasket(basket);
      }else{
        return this.deleteBasket(basket.userName);
      }
    }else {
      return;
    }
  }

  deleteBasket(userName: string) {
    return this.http.delete(this.baseURL + '/Basket/DeleteBasket/' + userName).pipe(
      tap({
        next:(response) => {
          this.basketSource.next(new Basket());
          localStorage.removeItem('basket_username');
        }, error: (err)=>{
          console.log('Error Occurred while deletin basket');
          console.log(err);
        }
      })
    )
  }

  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const item = items.find(x => x.productId == itemToAdd.productId);
    if(item) {
      item.quantity += quantity;
    }else {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd)
    }

    return items;
  }

  private mapProductItemToBasketItem(item: IProduct): IBasketItem {
    return  {
      productId: item.id,
      productName: item.name,
      price: item.price,
      imageFile: item.imageFile,
      quantity: 0
    }
  }

}
