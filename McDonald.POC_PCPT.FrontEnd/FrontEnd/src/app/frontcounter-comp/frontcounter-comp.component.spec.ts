import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FrontcounterCompComponent } from './frontcounter-comp.component';

describe('FrontcounterCompComponent', () => {
  let component: FrontcounterCompComponent;
  let fixture: ComponentFixture<FrontcounterCompComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FrontcounterCompComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FrontcounterCompComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
