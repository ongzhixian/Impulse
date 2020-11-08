import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoContactComponent } from './demo-contact.component';

describe('DemoContactComponent', () => {
  let component: DemoContactComponent;
  let fixture: ComponentFixture<DemoContactComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DemoContactComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DemoContactComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
