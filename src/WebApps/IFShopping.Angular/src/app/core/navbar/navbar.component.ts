import { Component, inject } from '@angular/core';
import { BasketService } from '../../basket/basket.service';
import { Observable, map } from 'rxjs';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {

  private basketService: BasketService = inject(BasketService);

  public itemsLength$: Observable<number> = this.basketService.basketSource$.pipe(
    map((basket) => basket.items.reduce((sum, item) => sum + item.quantity, 0))
  )

}
