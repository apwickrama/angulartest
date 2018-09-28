import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralCompComponent } from './general-comp.component';

describe('GeneralCompComponent', () => {
  let component: GeneralCompComponent;
  let fixture: ComponentFixture<GeneralCompComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GeneralCompComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GeneralCompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
