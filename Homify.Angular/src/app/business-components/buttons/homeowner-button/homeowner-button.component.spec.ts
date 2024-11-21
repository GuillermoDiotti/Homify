import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeownerButtonComponent } from './homeowner-button.component';

describe('HomeownerButtonComponent', () => {
  let component: HomeownerButtonComponent;
  let fixture: ComponentFixture<HomeownerButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeownerButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomeownerButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
