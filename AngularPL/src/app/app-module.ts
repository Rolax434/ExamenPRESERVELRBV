import { NgModule, provideBrowserGlobalErrorListeners, provideZonelessChangeDetection } from '@angular/core';
import { BrowserModule, provideClientHydration, withEventReplay } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Login } from './login/login';
import { Registro } from './registro/registro';
import { ListaClientes } from './lista-clientes/lista-clientes';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { Layout } from './layout/layout';
import { ListaTienda } from './lista-tienda/lista-tienda';
import { ListaArticulos } from './lista-articulos/lista-articulos';
import { FormArticulos } from './form-articulos/form-articulos';
import { FormTienda } from './form-tienda/form-tienda';
import { FormClientes } from './form-clientes/form-clientes';
import { TiendaArticulosDisponibles } from './tienda-articulos-disponibles/tienda-articulos-disponibles';
import { TiendaArticulosRelacionados } from './tienda-articulos-relacionados/tienda-articulos-relacionados';
import { CarritoCompra } from './carrito-compra/carrito-compra';
import { HistorialCompras } from './historial-compras/historial-compras';

@NgModule({
  declarations: [
    App,
    Login,
    Registro,
    ListaClientes,
    Layout,
    ListaTienda,
    ListaArticulos,
    FormArticulos,
    FormTienda,
    FormClientes,
    TiendaArticulosDisponibles,
    TiendaArticulosRelacionados,
    CarritoCompra,
    HistorialCompras
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZonelessChangeDetection(),
    provideClientHydration(withEventReplay())
  ],
  bootstrap: [App]
})
export class AppModule { }
