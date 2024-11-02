import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupportedDevicesComponent } from './supported-devices.component';

describe('SupportedDevicesComponent', () => {
  let component: SupportedDevicesComponent;
  let fixture: ComponentFixture<SupportedDevicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SupportedDevicesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SupportedDevicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
