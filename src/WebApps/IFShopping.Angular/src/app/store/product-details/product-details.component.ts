import { Component, Input, OnInit, inject } from '@angular/core';
import { IProduct } from '../../shared/models/product';
import { StoreService } from '../store.service';
import { ActivatedRoute } from '@angular/router';
import { Observable, concatMap, map, shareReplay, tap } from 'rxjs';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss'
})
export class ProductDetailsComponent implements OnInit {
  private storeService: StoreService = inject(StoreService);
  private activatedRoute: ActivatedRoute = inject(ActivatedRoute);
  public product$: Observable<IProduct> = this.activatedRoute.params.pipe(
    concatMap(params => this.storeService.getProductById(params["id"])),
    tap(console.log)
  )
  ngOnInit(): void {
    
  }

  loadProduct() {
    
  }
}
