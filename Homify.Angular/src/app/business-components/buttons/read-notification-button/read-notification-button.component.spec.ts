import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReadNotificationButtonComponent } from './read-notification-button.component';

describe('ReadNotificationButtonComponent', () => {
  let component: ReadNotificationButtonComponent;
  let fixture: ComponentFixture<ReadNotificationButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReadNotificationButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ReadNotificationButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
