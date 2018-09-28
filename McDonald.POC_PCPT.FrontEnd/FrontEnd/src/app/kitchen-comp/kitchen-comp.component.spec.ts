import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KitchenCompComponent } from './kitchen-comp.component';

describe('KitchenCompComponent', () => {
  let component: KitchenCompComponent;
  let fixture: ComponentFixture<KitchenCompComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KitchenCompComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KitchenCompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
