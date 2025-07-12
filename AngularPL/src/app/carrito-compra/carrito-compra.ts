import { Component } from '@angular/core';
import { ArticulosService } from '../services/articulos';
import { ClienteService } from '../services/cliente';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-carrito-compra',
  standalone: false,
  templateUrl: './carrito-compra.html',
  styleUrl: './carrito-compra.css'
})
export class CarritoCompra {
  articulos: any[] = [];
  cantidades: { [idArticulo: number]: number } = {};
  mensaje = '';
  error = '';

  constructor(
    private articuloService: ArticulosService,
    private clienteService: ClienteService,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.obtenerArticulos();
  }

  obtenerArticulos() {
    this.articuloService.getAll().subscribe(
      result => {
        this.articulos = result.objects || [];
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

  comprar(idArticulo: number) {
    const cantidad = this.cantidades[idArticulo];
    if (!cantidad || cantidad <= 0) {
      this.error = 'Por favor ingresa una cantidad válida.';
      return;
    }

    const cliente = JSON.parse(localStorage.getItem('cliente')!);
    const compra = {
      idCliente: cliente.idCliente,
      idArticulo: idArticulo,
      cantidad: cantidad
    };

    this.clienteService.comprar(compra).subscribe(
      result => {
        this.mensaje = 'Compra realizada exitosamente.';
        this.error = '';
        this.cantidades[idArticulo] = 0;
        this.obtenerArticulos();
        this.cd.detectChanges();
      },
      err => {
        this.error = typeof err.error === 'string' ? err.error : 'Error al realizar la compra.';
        this.mensaje = '';
        this.cd.detectChanges();
      }
    );
  }
}
