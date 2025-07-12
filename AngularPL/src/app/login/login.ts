import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClienteService } from '../services/cliente';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  username = '';
  password = '';
  error = '';

  

  constructor(private clienteService: ClienteService, private router: Router, private cd: ChangeDetectorRef) {}


  login() {
    this.clienteService.getAll().subscribe(result => {
      const clientes = result.objects;
      const cliente = clientes.find((c: any) =>
        c.userName === this.username && c.contrasenia === this.password
      );

      if (cliente) {
        localStorage.setItem('cliente', JSON.stringify(cliente));
        this.router.navigate(['lista-clientes']);
      } else {
        this.error = 'Usuario o contraseña incorrectos.';
      }
      this.cd.detectChanges();
    }, err => {
        this.error = typeof err.error === 'string'
          ? err.error
          : 'Error de conexión con el servidor.';
        this.cd.detectChanges();
      });
  }

  irARegistro() {
    this.router.navigate(['registro']);
  }
}
