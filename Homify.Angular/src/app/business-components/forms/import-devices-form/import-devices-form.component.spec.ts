import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportDevicesFormComponent } from './import-devices-form.component';

describe('ImportDevicesFormComponent', () => {
  let component: ImportDevicesFormComponent;
  let fixture: ComponentFixture<ImportDevicesFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ImportDevicesFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ImportDevicesFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
