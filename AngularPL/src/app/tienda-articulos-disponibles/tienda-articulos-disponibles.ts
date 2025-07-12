import { Component } from '@angular/core';
import { TiendaService } from '../services/tienda';
import { Router, ActivatedRoute } from '@angular/router';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-tienda-articulos-disponibles',
  standalone: false,
  templateUrl: './tienda-articulos-disponibles.html',
  styleUrl: './tienda-articulos-disponibles.css'
})
export class TiendaArticulosDisponibles {
idTienda!: number;
  articulos: any[] = [];
  error = '';
  mensaje = '';

  constructor(private tiendaService: TiendaService, private route: ActivatedRoute, private router: Router, private cd: ChangeDetectorRef) {}

  ngOnInit() {
    this.idTienda = +this.route.snapshot.queryParamMap.get('id')!;
    this.tiendaService.getArticulosDisponibles(this.idTienda).subscribe(result => {
      if (result.correct) {
        this.articulos = result.objects;
        this.cd.detectChanges();
      } else {
        this.error = result.errorMessage;
        this.cd.detectChanges();
      }
    }, err => {
        this.error = typeof err.error === 'string'
          ? err.error
          : 'Error al intentar eliminar el artículo.';
        this.cd.detectChanges();
        });
  }

  relacionar(idArticulo: number) {
    this.tiendaService.relacionarArticulo(this.idTienda, idArticulo).subscribe(result => {
      if (result.correct) {
        this.mensaje = 'Artículo relacionado correctamente';
        this.articulos = this.articulos.filter(a => a.idArticulo !== idArticulo);
        this.cd.detectChanges();
      } else {
        this.error = result.errorMessage;
        this.cd.detectChanges();
      }
    }, err => {
        this.error = typeof err.error === 'string'
          ? err.error
          : 'Error al intentar eliminar el artículo.';
        this.cd.detectChanges();
        });
  }

  irALista() {
    this.router.navigate(['lista-tienda']);
  }
}
