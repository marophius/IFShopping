import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker'
import { NavbarComponent } from './components/navbar/navbar.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule, 
    RouterOutlet,
    HttpClientModule,
    BsDatepickerModule,
    NavbarComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  title = 'IFShopping';
  private http = inject(HttpClient)

  ngOnInit(): void {
      this.http.get('http://localhost:9010/Catalog/GetProductsByBrandName/Adidas')
        .subscribe({
          next: (products) => console.table(products),
          error: (error: Error) => console.log(error)
        })
  }
}
