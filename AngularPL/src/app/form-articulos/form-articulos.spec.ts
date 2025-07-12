import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormArticulos } from './form-articulos';

describe('FormArticulos', () => {
  let component: FormArticulos;
  let fixture: ComponentFixture<FormArticulos>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FormArticulos]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormArticulos);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
