import { Component, OnInit } from '@angular/core';
import { TiendaService } from '../services/tienda';
import { ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lista-tienda',
  standalone: false,
  templateUrl: './lista-tienda.html',
  styleUrl: './lista-tienda.css'
})
export class ListaTienda implements OnInit {
  tiendas: any[] = [];
  error = '';
  mensaje = '';

  constructor(private tiendaService: TiendaService, private router: Router, private cd: ChangeDetectorRef) {}

  ngOnInit() {
    this.obtenerTiendas();
  }

  obtenerTiendas() {
    this.tiendaService.getAll().subscribe(
      result => {
        if (result.correct && result.objects) {
          this.tiendas = result.objects;
          this.cd.detectChanges();
        } else {
          this.error = 'No se pudieron obtener las tiendas.';
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

  eliminar(id: number) {
  const confirmacion = confirm('¿Estás seguro de que deseas eliminar esta tienda? Se elimnara tambien cualquier enlace con articulos asociado');

  if (confirmacion) {
    this.tiendaService.delete(id).subscribe(
      result => {
        if (result.correct) {
          this.mensaje = 'La tienda se elimino correctamente';
          this.obtenerTiendas();
        } else {
          this.error = result.errorMessage || 'No se pudo eliminar la tienda.';
          this.cd.detectChanges();
        }
      },
      err => {
        this.error = typeof err.error === 'string'
          ? err.error
          : 'Error al intentar eliminar la tienda.';
        this.cd.detectChanges();
        }
      );
    }
  }
  IraFormulario() {
    this.router.navigate(['form-tienda']);
  }

  editar(id: number) {
    this.router.navigate(['form-tienda'], { queryParams: { id: id } });
  }

  verArticulosRelacionados(idTienda: number) {
    this.router.navigate(['tienda-articulos-relacionados'], { queryParams: { id: idTienda } });
  }

  verArticulosDisponibles(idTienda: number) {
    this.router.navigate(['tienda-articulos-disponibles'], { queryParams: { id: idTienda } });
  }

}
