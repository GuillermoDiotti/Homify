import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurnOffDeviceButtonComponent } from './turn-off-device-button.component';

describe('TurnOffDeviceButtonComponent', () => {
  let component: TurnOffDeviceButtonComponent;
  let fixture: ComponentFixture<TurnOffDeviceButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TurnOffDeviceButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TurnOffDeviceButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
