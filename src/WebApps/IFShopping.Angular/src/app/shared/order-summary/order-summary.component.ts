import { Component, inject } from '@angular/core';
import { Observable, map } from 'rxjs';
import { BasketService } from '../../basket/basket.service';

@Component({
  selector: 'app-order-summary',
  templateUrl: './order-summary.component.html',
  styleUrl: './order-summary.component.scss'
})
export class OrderSummaryComponent {
  private basketService: BasketService = inject(BasketService);
  public basketTotal$: Observable<number> = this.basketService.basketSource$.pipe(
    map((basket) => basket.items.reduce((x, y) => (y.price * y.quantity) + x, 0)),
  );
}
