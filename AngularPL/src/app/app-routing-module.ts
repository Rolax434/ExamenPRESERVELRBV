import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Login } from './login/login';
import { Registro } from './registro/registro';
import { ListaClientes } from './lista-clientes/lista-clientes';
import { ListaTienda } from './lista-tienda/lista-tienda';
import { ListaArticulos } from './lista-articulos/lista-articulos';
import { Layout } from './layout/layout';
import { AuthGuard } from './guards/auth-guard';
import { FormArticulos } from './form-articulos/form-articulos';
import { FormTienda } from './form-tienda/form-tienda';
import { FormClientes } from './form-clientes/form-clientes';
import { TiendaArticulosRelacionados } from './tienda-articulos-relacionados/tienda-articulos-relacionados';
import { TiendaArticulosDisponibles } from './tienda-articulos-disponibles/tienda-articulos-disponibles';
import { CarritoCompra } from './carrito-compra/carrito-compra';
import { HistorialCompras } from './historial-compras/historial-compras';

const routes: Routes = [
  { path: '', component: Login },
  { path: 'registro', component: Registro },
  {
    path: '',
    component: Layout,
    canActivate: [AuthGuard],
    children: [
      { path: 'lista-clientes', component: ListaClientes},
      { path: 'lista-tienda', component: ListaTienda },
      { path: 'lista-articulos', component: ListaArticulos },
      { path: 'form-clientes', component: FormClientes},
      { path: 'login', component: Login},
      { path: 'carrito-compra', component: CarritoCompra},
      { path: 'historial', component: HistorialCompras},
      { path: '', redirectTo: 'lista-clientes', pathMatch: 'full' }
    ]
  },
  { path: 'form-articulos', component: FormArticulos, canActivate: [AuthGuard]},
  { path: 'form-tienda', component: FormTienda, canActivate: [AuthGuard]},
  { path: 'tienda-articulos-relacionados', component: TiendaArticulosRelacionados, canActivate: [AuthGuard]},
  { path: 'tienda-articulos-disponibles', component: TiendaArticulosDisponibles, canActivate: [AuthGuard]},
  { path: '**', redirectTo: '/login'}
  
];
@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
