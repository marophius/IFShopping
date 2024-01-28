import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker'
import { NavbarComponent } from './components/navbar/navbar.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { map, tap } from 'rxjs';

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
  products = signal<any[]>([]);

  private http = inject(HttpClient)

  ngOnInit(): void {
      this.http.get<any[]>('http://localhost:9010/Catalog/GetAllProducts')
        .pipe(
          tap(data => console.log(data)),
          map((data: any) => data.data)
        )
        .subscribe({
          next: (response: any[]) => {
            this.products.set(response)
          },
          error: (error: Error) => console.log(error)
        })
  }
}
