import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportDevicesPageComponent } from './import-devices-page.component';

describe('ImportDevicesPageComponent', () => {
  let component: ImportDevicesPageComponent;
  let fixture: ComponentFixture<ImportDevicesPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ImportDevicesPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ImportDevicesPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
