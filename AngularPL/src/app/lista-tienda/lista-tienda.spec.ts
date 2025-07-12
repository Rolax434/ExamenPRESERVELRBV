import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaTienda } from './lista-tienda';

describe('ListaTienda', () => {
  let component: ListaTienda;
  let fixture: ComponentFixture<ListaTienda>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListaTienda]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListaTienda);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
