import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TiendaArticulosRelacionados } from './tienda-articulos-relacionados';

describe('TiendaArticulosRelacionados', () => {
  let component: TiendaArticulosRelacionados;
  let fixture: ComponentFixture<TiendaArticulosRelacionados>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TiendaArticulosRelacionados]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TiendaArticulosRelacionados);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
