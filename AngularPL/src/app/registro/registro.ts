import { Component } from '@angular/core';
import { ClienteService } from '../services/cliente';
import { Router } from '@angular/router';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-registro',
  standalone: false,
  templateUrl: './registro.html',
  styleUrl: './registro.css'
})
export class Registro {
  cliente: any = {};
  mensaje = '';
  error = '';

  constructor(private clienteService: ClienteService, private router: Router, private cd: ChangeDetectorRef) {}

  registrar() {
    this.clienteService.add(this.cliente).subscribe(result => {
      if (result.correct) {
        this.mensaje = 'Cliente registrado exitosamente';
        setTimeout(() => this.router.navigate(['/']), 2000);
      } else {
        this.error = result.errorMessage || 'No se pudo registrar';
      }
      this.cd.detectChanges();
    }, err => {
        this.error = typeof err.error === 'string'
          ? err.error
          : 'Error de conexión con el servidor.';
        this.cd.detectChanges();
      });
  }
  irALogin() {
    this.router.navigate(['']);
  }
}
