import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TiendaService {
  readonly apiUrl = 'https://localhost:7245/api/tienda'; // Ajusta el puerto si es diferente

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<any>(`${this.apiUrl}/GetAll`);
  }

  add(tienda: any) {
    return this.http.post<any>(`${this.apiUrl}/Add`, tienda);
  }

  
  getById(id: number) {
  return this.http.get<any>(`${this.apiUrl}/GetByID?idTienda=${id}`);
  }

  update(articulo: any) {
    return this.http.put<any>(`${this.apiUrl}/Update`, articulo);
  }

  delete(id: number) {
    return this.http.delete<any>(`${this.apiUrl}/Delete?idTienda=${id}`);
  }

  getArticulosDisponibles(idTienda: number) {
    return this.http.get<any>(`${this.apiUrl}/GetArtDisponibles?IdTienda=${idTienda}`);
  }

  getArticulosRelacionados(idTienda: number) {
    return this.http.get<any>(`${this.apiUrl}/GetArtRelacionados?IdTienda=${idTienda}`);
  }

  relacionarArticulo(idTienda: number, idArticulo: number) {
    return this.http.post<any>(`${this.apiUrl}/RelacionarArticulo?idTienda=${idTienda}&idArticulo=${idArticulo}`, {});
  }
}
