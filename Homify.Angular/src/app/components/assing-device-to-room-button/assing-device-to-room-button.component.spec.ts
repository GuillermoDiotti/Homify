import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssingDeviceToRoomButtonComponent } from './assing-device-to-room-button.component';

describe('AssingDeviceToRoomButtonComponent', () => {
  let component: AssingDeviceToRoomButtonComponent;
  let fixture: ComponentFixture<AssingDeviceToRoomButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AssingDeviceToRoomButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AssingDeviceToRoomButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
