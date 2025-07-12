import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ArticulosService } from '../services/articulos';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-form-articulos',
  standalone: false,
  templateUrl: './form-articulos.html',
  styleUrl: './form-articulos.css'
})
export class FormArticulos {
  articulo: any = {};
  mensaje = '';
  error = '';
  imagenPreview: string | null = null;
  esEdicion = false;

  constructor(
    private route: ActivatedRoute,
    private articulosService: ArticulosService,
    private router: Router,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.queryParamMap.get('id');
    if (id) {
      this.esEdicion = true;
      this.articulosService.getById(Number(id)).subscribe(result => {
        if (result.correct) {
          this.articulo = result.object;
          if (this.articulo.imagen) {
            this.imagenPreview = `data:image/*;base64,${this.articulo.imagen}`;
          }
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
    const accion = this.esEdicion ? this.articulosService.update(this.articulo) : this.articulosService.add(this.articulo);
    accion.subscribe(result => {
      if (result.correct) {
        this.mensaje = this.esEdicion ? 'Artículo actualizado exitosamente' : 'Artículo registrado exitosamente';
        setTimeout(() => this.router.navigate(['lista-articulos']), 2000);
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
    this.router.navigate(['lista-articulos']);
  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        const base64Full = reader.result as string;
        const base64 = base64Full.split(',')[1];
        this.articulo.imagen = base64;
        this.imagenPreview = base64Full;
        this.cd.detectChanges();
      };
      reader.readAsDataURL(file);
    }
  }
}
