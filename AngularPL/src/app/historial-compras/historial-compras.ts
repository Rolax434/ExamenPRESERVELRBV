import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { ClienteService } from '../services/cliente';
import { ChangeDetectorRef } from '@angular/core';


@Component({
  selector: 'app-historial-compras',
  standalone: false,
  templateUrl: './historial-compras.html',
  styleUrl: './historial-compras.css'
})
export class HistorialCompras implements OnInit {
  historial: any[] = [];
  error = '';

  constructor(private clienteService: ClienteService, private cd: ChangeDetectorRef) {}

  ngOnInit() {
    const cliente = JSON.parse(localStorage.getItem('cliente')!);
    this.clienteService.getHistorial(cliente.idCliente).subscribe(
      result => {
        this.historial = result.objects || [];
        this.cd.detectChanges();
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
