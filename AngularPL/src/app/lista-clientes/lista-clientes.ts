import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services/cliente';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-lista-clientes',
  standalone: false,
  templateUrl: './lista-clientes.html',
  styleUrl: './lista-clientes.css'
})
export class ListaClientes implements OnInit {
  clientes: any[] = [];
  error = '';

  constructor(private clienteService: ClienteService, private cd: ChangeDetectorRef) {}

  ngOnInit() {
    this.obtenerClientes();
  }

  obtenerClientes() {
    this.clienteService.getAll().subscribe(
      result => {
        if (result.correct && result.objects) {
          this.clientes = result.objects;
          this.cd.detectChanges();
        } else {
          this.error = 'No se pudieron obtener los clientes.';
          this.cd.detectChanges();
        }
      },
      err => {
        this.error = typeof err.error === 'string'
          ? err.error
          : 'Error de conexión con el servidor.';
        this.cd.detectChanges();
      }
    );
  }
}