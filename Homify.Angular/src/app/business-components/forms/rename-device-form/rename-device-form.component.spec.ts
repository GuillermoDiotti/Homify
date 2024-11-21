import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RenameDeviceFormComponent } from './rename-device-form.component';

describe('RenameDeviceFormComponent', () => {
  let component: RenameDeviceFormComponent;
  let fixture: ComponentFixture<RenameDeviceFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RenameDeviceFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RenameDeviceFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
