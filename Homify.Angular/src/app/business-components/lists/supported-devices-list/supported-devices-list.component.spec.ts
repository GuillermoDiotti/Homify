import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupportedDevicesListComponent } from './supported-devices-list.component';

describe('SupportedDevicesListComponent', () => {
  let component: SupportedDevicesListComponent;
  let fixture: ComponentFixture<SupportedDevicesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SupportedDevicesListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SupportedDevicesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
