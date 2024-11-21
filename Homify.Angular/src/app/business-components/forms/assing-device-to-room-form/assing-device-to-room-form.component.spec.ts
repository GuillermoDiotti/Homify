import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssingDeviceToRoomFormComponent } from './assing-device-to-room-form.component';

describe('AssingDeviceToRoomFormComponent', () => {
  let component: AssingDeviceToRoomFormComponent;
  let fixture: ComponentFixture<AssingDeviceToRoomFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AssingDeviceToRoomFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AssingDeviceToRoomFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
