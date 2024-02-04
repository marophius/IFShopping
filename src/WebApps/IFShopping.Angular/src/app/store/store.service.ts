import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { Observable, map } from 'rxjs';
import { IPagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/type';
import { StoreParams } from '../shared/models/storeParams';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  private readonly baseURL:string = 'http://localhost:9010/';

  constructor(private http: HttpClient) { }

  getProductById(id: string): Observable<IProduct> {
    return this.http.get<IProduct>(this.baseURL + 'Catalog/GetProductById/' + id);
  }

  getProducts(storeParams: StoreParams) {
    let params = new HttpParams();
    if(storeParams.brandId){
      params = params.append('brandId', storeParams.brandId);
    }
    if(storeParams.typeId){
      params = params.append('typeId', storeParams.typeId);
    }
    if(storeParams.search){
      params = params.append('search', storeParams.search);
    }

    params = params.append('sort', storeParams.sort);
    params = params.append('pageIndex', storeParams.pageNumber);
    params = params.append('pageSize', storeParams.pageSize);
    return this.http.get<IPagination<IProduct[]>>(this.baseURL + 'Catalog/GetAllProducts', {params: params});
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseURL + 'Catalog/GetAllBrands')
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseURL + 'Catalog/GetAllTypes')
  }
}
