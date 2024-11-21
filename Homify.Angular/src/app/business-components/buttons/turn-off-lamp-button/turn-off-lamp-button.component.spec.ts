import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurnOffLampButtonComponent } from './turn-off-lamp-button.component';

describe('TurnOffLampButtonComponent', () => {
  let component: TurnOffLampButtonComponent;
  let fixture: ComponentFixture<TurnOffLampButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TurnOffLampButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TurnOffLampButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
