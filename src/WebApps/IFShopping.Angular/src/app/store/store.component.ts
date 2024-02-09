import { Component, ElementRef, OnDestroy, OnInit, ViewChild, WritableSignal, signal } from '@angular/core';
import { StoreService } from './store.service';
import { IProduct } from '../shared/models/product';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/type';
import { StoreParams } from '../shared/models/storeParams';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { BasketService } from '../basket/basket.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrl: './store.component.scss'
})
export class StoreComponent implements OnInit, OnDestroy {

  public products: WritableSignal<IProduct[]> = signal<IProduct[]>([]);
  public brands: WritableSignal<IBrand[]> = signal<IBrand[]>([]);
  public types: WritableSignal<IType[]> = signal<IType[]>([]);
  public storeParams: StoreParams = new StoreParams();
  public sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Ascending', value: 'priceAsc'},
    {name: 'Price: Descending', value: 'priceDesc'}
  ];
  public totalCount: number = 0;
  @ViewChild('search', {static: false})
  public searchTerm!: ElementRef<HTMLInputElement>;
  public subscription!: Subscription;

  constructor(
    private storeService: StoreService,
    private basketService: BasketService) {
    
  }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.storeService.getProducts(this.storeParams).subscribe({
      next: (response) => {
        this.products.set(response.data);
        this.storeParams.pageNumber = response.pageIndex;
        this.storeParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
      error: (error: Error) => console.log(error)
    })
  }

  getBrands() {
    this.storeService.getBrands().subscribe({
      next: (brands) => {
        this.brands.set([{id: '', name: 'All'}, ...brands]);
        console.log(brands)
      },
      error: (error: Error) => console.log(error)
    })
  }

  getTypes() {
    this.storeService.getTypes().subscribe({
      next: (types) => {
        this.types.set([{id: '', name: 'All'}, ...types]);
        console.log(types)
      },
      error: (error: Error) => console.log(error)
    })
  }

  onBrandSelect(id: string) {
    this.storeParams.brandId = id;
    this.getProducts();
  }

  onTypeSelect(id: string) {
    this.storeParams.typeId = id;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.storeParams.sort = sort;
  }

  onPageChanged(event: PageChangedEvent) {
    this.storeParams.pageNumber = event.page;
    this.getProducts();
  }

  onSearch() {
    this.storeParams.search = this.searchTerm.nativeElement.value;
    this.storeParams.pageNumber = 1;
    this.getProducts()
  }

  onReset() {
    if(this.searchTerm) {
      this.searchTerm.nativeElement.value = '';
      this.storeParams = new StoreParams();
      this.getBrands();
    }
  }

  addItemToBasket(item: IProduct) {
    this.subscription = this.basketService.addItemToBasket(item)
  }

  ngOnDestroy(): void {
      this.subscription?.unsubscribe();
  }
}
