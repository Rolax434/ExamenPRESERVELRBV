import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TiendaArticulosDisponibles } from './tienda-articulos-disponibles';

describe('TiendaArticulosDisponibles', () => {
  let component: TiendaArticulosDisponibles;
  let fixture: ComponentFixture<TiendaArticulosDisponibles>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TiendaArticulosDisponibles]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TiendaArticulosDisponibles);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
