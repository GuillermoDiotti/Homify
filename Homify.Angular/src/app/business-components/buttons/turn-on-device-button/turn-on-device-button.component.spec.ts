import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurnOnDeviceButtonComponent } from './turn-on-device-button.component';

describe('TurnOnDeviceButtonComponent', () => {
  let component: TurnOnDeviceButtonComponent;
  let fixture: ComponentFixture<TurnOnDeviceButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TurnOnDeviceButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TurnOnDeviceButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
