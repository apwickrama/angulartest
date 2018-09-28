import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DrivethruCompComponent } from './drivethru-comp.component';

describe('DrivethruCompComponent', () => {
  let component: DrivethruCompComponent;
  let fixture: ComponentFixture<DrivethruCompComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DrivethruCompComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DrivethruCompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
