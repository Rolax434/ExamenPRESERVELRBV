import { Component } from '@angular/core';
import { TiendaService } from '../services/tienda';
import { Route, ActivatedRoute, Router } from '@angular/router';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-tienda-articulos-relacionados',
  standalone: false,
  templateUrl: './tienda-articulos-relacionados.html',
  styleUrl: './tienda-articulos-relacionados.css'
})
export class TiendaArticulosRelacionados {
  idTienda!: number;
  articulos: any[] = [];
  error = '';

  constructor(private tiendaService: TiendaService, private route: ActivatedRoute, private router: Router, private cd: ChangeDetectorRef) {}

  ngOnInit() {
    this.idTienda = +this.route.snapshot.queryParamMap.get('id')!;
    this.tiendaService.getArticulosRelacionados(this.idTienda).subscribe(result => {
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
  irALista() {
    this.router.navigate(['lista-tienda']);
  }
}
