import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RenameDeviceButtonComponent } from './rename-device-button.component';

describe('RenameDeviceButtonComponent', () => {
  let component: RenameDeviceButtonComponent;
  let fixture: ComponentFixture<RenameDeviceButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RenameDeviceButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RenameDeviceButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
