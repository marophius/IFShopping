import { Component, OnInit, WritableSignal, signal } from '@angular/core';
import { StoreService } from './store.service';
import { IProduct } from '../shared/models/product';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrl: './store.component.scss'
})
export class StoreComponent implements OnInit {

  public products: WritableSignal<IProduct[]> = signal<IProduct[]>([]);

  constructor(private storeService: StoreService) {
    
  }

  ngOnInit(): void {
    this.storeService.getProducts().subscribe({
      next: (products) => {
        this.products.set(products);
      },
      error: (error: Error) => console.log(error)
    })
  }
}
