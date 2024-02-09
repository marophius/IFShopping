import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';
import { IProduct } from '../../shared/models/product';

@Component({
  selector: 'app-product-items',
  templateUrl: './product-items.component.html',
  styleUrl: './product-items.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProductItemsComponent {

  @Input() product!: IProduct;
  @Output('onAddItemToBasket')
  public eventEmmiter: EventEmitter<IProduct> = new EventEmitter<IProduct>();

  constructor() {
    

  }

  addItemToBasket() {
    this.eventEmmiter.emit(this.product);
  }
}
