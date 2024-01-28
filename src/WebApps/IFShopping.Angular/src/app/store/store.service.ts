import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { map } from 'rxjs';
import { IPagination } from '../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  private readonly baseURL:string = 'http://localhost:9010/';

  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get<IPagination<IProduct[]>>(this.baseURL + 'Catalog/GetAllProducts').pipe(
      map((res: IPagination<IProduct[]>) => res.data)
    )
  }
}
