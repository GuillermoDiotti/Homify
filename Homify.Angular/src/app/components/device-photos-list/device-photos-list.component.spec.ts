import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DevicePhotosListComponent } from './device-photos-list.component';

describe('DevicePhotosListComponent', () => {
  let component: DevicePhotosListComponent;
  let fixture: ComponentFixture<DevicePhotosListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DevicePhotosListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DevicePhotosListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
