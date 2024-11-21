import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TurnOnLampButtonComponent } from './turn-on-lamp-button.component';

describe('TurnOnLampButtonComponent', () => {
  let component: TurnOnLampButtonComponent;
  let fixture: ComponentFixture<TurnOnLampButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TurnOnLampButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TurnOnLampButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
