import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ArticulosService {
  readonly apiUrl = 'https://localhost:7245/api/Articulo'; // Ajusta el puerto si es diferente

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<any>(`${this.apiUrl}/GetAll`);
  }

  add(articulo: any) {
    return this.http.post<any>(`${this.apiUrl}/Add`, articulo);
  }

  getById(id: number) {
  return this.http.get<any>(`${this.apiUrl}/GetByID?idArticulo=${id}`);
  }

  update(articulo: any) {
    return this.http.put<any>(`${this.apiUrl}/Update`, articulo);
  }

  delete(id: number) {
    return this.http.delete<any>(`${this.apiUrl}/Delete?idArticulo=${id}`);
  }
  
}
