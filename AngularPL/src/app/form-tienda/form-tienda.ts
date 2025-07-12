import { Component } from '@angular/core';
import { TiendaService } from '../services/tienda';
import { ActivatedRoute,Router } from '@angular/router';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-form-tienda',
  standalone: false,
  templateUrl: './form-tienda.html',
  styleUrl: './form-tienda.css'
})
export class FormTienda {
  tienda: any = {};
  mensaje = '';
  error = '';
  imagenPreview: string | null = null;
  esEdicion = false;

  constructor(
    private route: ActivatedRoute,
    private tiendaService: TiendaService,
    private router: Router,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.queryParamMap.get('id');
    if (id) {
      this.esEdicion = true;
      this.tiendaService.getById(Number(id)).subscribe(result => {
        if (result.correct) {
          this.tienda = result.object;
          this.cd.detectChanges();
        } else {
          this.error = result.errorMessage;
          this.cd.detectChanges();
        }
      }, err => {
        this.error = typeof err.error === 'string'
          ? err.error
          : 'Error de conexión con el servidor.';
        this.cd.detectChanges();
      });
    }
  }

  agregar() {
    const accion = this.esEdicion ? this.tiendaService.update(this.tienda) : this.tiendaService.add(this.tienda);
    accion.subscribe(result => {
      if (result.correct) {
        this.mensaje = this.esEdicion ? 'Tienda actualizada exitosamente' : 'Tienda registrada exitosamente';
        setTimeout(() => this.router.navigate(['lista-tienda']), 2000);
      } else {
        this.error = result.errorMessage || 'Error en la operación';
      }
      this.cd.detectChanges();
    }, err => {
        this.error = typeof err.error === 'string'
          ? err.error
          : 'Error de conexión con el servidor.';
        this.cd.detectChanges();
      });
  }

  irALista() {
    this.router.navigate(['lista-tienda']);
  }
}
