import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenerateNotificationButtonComponent } from './generate-notification-button.component';

describe('GenerateNotificationButtonComponent', () => {
  let component: GenerateNotificationButtonComponent;
  let fixture: ComponentFixture<GenerateNotificationButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GenerateNotificationButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GenerateNotificationButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
