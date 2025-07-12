import { Component } from '@angular/core';
import { ArticulosService } from '../services/articulos';
import { ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lista-articulos',
  standalone: false,
  templateUrl: './lista-articulos.html',
  styleUrl: './lista-articulos.css'
})
export class ListaArticulos {
  articulos: any[] = [];
  error = '';
  mensaje = '';

  constructor(private articulosService: ArticulosService, private cd: ChangeDetectorRef, private router: Router) {}

  ngOnInit() {
    this.obtenerArticulos();
  }

  obtenerArticulos() {
    this.articulosService.getAll().subscribe(
      result => {
        if (result.correct && result.objects) {
          this.articulos = result.objects;
          this.cd.detectChanges();
        } else {
          this.error = 'No se pudieron obtener los articulos.';
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
  const confirmacion = confirm('¿Estás seguro de que deseas eliminar este artículo? Se elimnara tambien cualquier enlace con tienda o historial de compra asociado');

  if (confirmacion) {
    this.articulosService.delete(id).subscribe(
      result => {
        if (result.correct) {
          this.mensaje = 'El articulo se elimino correctamente';
          this.obtenerArticulos();
        } else {
          this.error = result.errorMessage || 'No se pudo eliminar el artículo.';
          this.cd.detectChanges();
        }
      },
      err => {
        this.error = typeof err.error === 'string'
          ? err.error
          : 'Error al intentar eliminar el artículo.';
        this.cd.detectChanges();
        }
      );
    }
  }
  IraFormulario() {
    this.router.navigate(['form-articulos']);
  }

  editar(id: number) {
    this.router.navigate(['form-articulos'], { queryParams: { id: id } });
  }
}
