import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormTienda } from './form-tienda';

describe('FormTienda', () => {
  let component: FormTienda;
  let fixture: ComponentFixture<FormTienda>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FormTienda]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormTienda);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
