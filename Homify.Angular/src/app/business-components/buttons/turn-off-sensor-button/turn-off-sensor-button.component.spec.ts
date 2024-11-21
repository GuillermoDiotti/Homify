import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurnOffSensorButtonComponent } from './turn-off-sensor-button.component';

describe('TurnOffSensorButtonComponent', () => {
  let component: TurnOffSensorButtonComponent;
  let fixture: ComponentFixture<TurnOffSensorButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TurnOffSensorButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TurnOffSensorButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
