import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoAboutComponent } from './demo-about.component';

describe('DemoAboutComponent', () => {
  let component: DemoAboutComponent;
  let fixture: ComponentFixture<DemoAboutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DemoAboutComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DemoAboutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
