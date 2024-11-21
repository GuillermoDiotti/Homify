import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateOwnerFormComponent } from './create-owner-form.component';

describe('CreateOwnerFormComponent', () => {
  let component: CreateOwnerFormComponent;
  let fixture: ComponentFixture<CreateOwnerFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateOwnerFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateOwnerFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
