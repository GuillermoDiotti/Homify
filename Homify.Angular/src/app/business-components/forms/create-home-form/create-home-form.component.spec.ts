import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateHomeFormComponent } from './create-home-form.component';

describe('CreateHomeFormComponent', () => {
  let component: CreateHomeFormComponent;
  let fixture: ComponentFixture<CreateHomeFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateHomeFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateHomeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
