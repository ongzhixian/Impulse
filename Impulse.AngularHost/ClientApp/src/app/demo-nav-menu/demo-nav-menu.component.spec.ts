import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoNavMenuComponent } from './demo-nav-menu.component';

describe('DemoNavMenuComponent', () => {
  let component: DemoNavMenuComponent;
  let fixture: ComponentFixture<DemoNavMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DemoNavMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DemoNavMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
