import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DemoNewsComponent } from './demo-news.component';

describe('DemoNewsComponent', () => {
  let component: DemoNewsComponent;
  let fixture: ComponentFixture<DemoNewsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DemoNewsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DemoNewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
