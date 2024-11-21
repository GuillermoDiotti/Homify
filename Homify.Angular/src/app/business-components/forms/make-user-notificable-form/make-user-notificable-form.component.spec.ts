import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MakeUserNotificableFormComponent } from './make-user-notificable-form.component';

describe('MakeUserNotificableFormComponent', () => {
  let component: MakeUserNotificableFormComponent;
  let fixture: ComponentFixture<MakeUserNotificableFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MakeUserNotificableFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MakeUserNotificableFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
