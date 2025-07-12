import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  readonly apiUrl = 'https://localhost:7245/api/cliente'; // Ajusta el puerto si es diferente

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<any>(`${this.apiUrl}/GetAll`);
  }

  add(cliente: any) {
    return this.http.post<any>(`${this.apiUrl}/Add`, cliente);
  }

  getByUsernameAndPassword(username: string, password: string) {
    return this.http.get<any>(`${this.apiUrl}/GetAll`);
  }

  getById(id: number) {
  return this.http.get<any>(`${this.apiUrl}/GetByID?idCliente=${id}`);
  }

  update(articulo: any) {
    return this.http.put<any>(`${this.apiUrl}/Update`, articulo);
  }

  delete(id: number) {
    return this.http.delete<any>(`${this.apiUrl}/Delete?idCliente=${id}`);
  }

  comprar(compra: any) {
    return this.http.post<any>(`${this.apiUrl}/comprar`, compra);
  }

  getHistorial(idCliente: number) {
    return this.http.get<any>(`${this.apiUrl}/GetHistorialCompras?idCliente=` + idCliente);
  }
}
