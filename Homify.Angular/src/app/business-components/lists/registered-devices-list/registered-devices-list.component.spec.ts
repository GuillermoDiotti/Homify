import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisteredDevicesListComponent } from './registered-devices-list.component';

describe('RegisteredDevicesListComponent', () => {
  let component: RegisteredDevicesListComponent;
  let fixture: ComponentFixture<RegisteredDevicesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegisteredDevicesListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RegisteredDevicesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
