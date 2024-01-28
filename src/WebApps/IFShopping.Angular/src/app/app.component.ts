import { HttpClient } from '@angular/common/http';
import { Component, inject, signal } from '@angular/core';
import { map } from 'rxjs';
import { IProduct } from './shared/models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'IFShopping.Angular';
}
