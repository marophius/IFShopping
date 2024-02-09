import { Component, inject } from '@angular/core';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  private bcService: BreadcrumbService = inject(BreadcrumbService);
  public breadCrumb$ = this.bcService.breadcrumbs$;
}
