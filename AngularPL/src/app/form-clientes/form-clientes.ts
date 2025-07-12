import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ClienteService } from '../services/cliente';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-form-clientes',
  standalone: false,
  templateUrl: './form-clientes.html',
  styleUrl: './form-clientes.css'
})
export class FormClientes {
  cliente: any = {};
  mensaje = '';
  error = '';

  constructor(
    private route: ActivatedRoute,
    private clienteService: ClienteService,
    private router: Router,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit() {
    const clienteData = localStorage.getItem('cliente');
    var id = null;

    if (clienteData) {
      const cliente = JSON.parse(clienteData);
      id = cliente.idCliente;
    }
    if (id) {
      this.clienteService.getById(Number(id)).subscribe(result => {
        if (result.correct) {
          this.cliente = result.object;
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

  guardar() {
    this.clienteService.update(this.cliente).subscribe(result => {
      if (result.correct) {
        this.mensaje = 'Cliente actualizado exitosamente';
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

  eliminar(id: number) {
  const confirmacion = confirm('¿Estás seguro de que deseas eliminar tu cuenta? Se elimnara tambien cualquier enlace con articulos de historial de compra asociado');

  if (confirmacion) {
    this.clienteService.delete(id).subscribe(
      result => {
        if (result.correct) {
          this.mensaje = 'Su cuenta se elimino correctamente';
          setTimeout(() => this.irALogin(), 2000);
          
        } else {
          this.error = result.errorMessage || 'No se pudo eliminar la cuenta.';
          this.cd.detectChanges();
        }
      },
      err => {
        this.error = typeof err.error === 'string'
          ? err.error
          : 'Error al intentar eliminarla cuenta.';
        this.cd.detectChanges();
        }
      );
    }
  }

  irALogin() {
    localStorage.removeItem('cliente');
    this.router.navigate(['']);
  }
}
