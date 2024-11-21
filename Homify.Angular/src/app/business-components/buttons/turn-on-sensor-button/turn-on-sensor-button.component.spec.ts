import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurnOnSensorButtonComponent } from './turn-on-sensor-button.component';

describe('TurnOnSensorButtonComponent', () => {
  let component: TurnOnSensorButtonComponent;
  let fixture: ComponentFixture<TurnOnSensorButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TurnOnSensorButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TurnOnSensorButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
