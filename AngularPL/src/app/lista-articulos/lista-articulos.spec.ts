import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaArticulos } from './lista-articulos';

describe('ListaArticulos', () => {
  let component: ListaArticulos;
  let fixture: ComponentFixture<ListaArticulos>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListaArticulos]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListaArticulos);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
