import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenerateNotificationFormComponent } from './generate-notification-form.component';

describe('GenerateNotificationFormComponent', () => {
  let component: GenerateNotificationFormComponent;
  let fixture: ComponentFixture<GenerateNotificationFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GenerateNotificationFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GenerateNotificationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
