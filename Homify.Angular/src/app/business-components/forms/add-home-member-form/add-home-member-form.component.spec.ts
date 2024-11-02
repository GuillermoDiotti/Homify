import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddHomeMemberFormComponent } from './add-home-member-form.component';

describe('AddHomeMemberFormComponent', () => {
  let component: AddHomeMemberFormComponent;
  let fixture: ComponentFixture<AddHomeMemberFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddHomeMemberFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddHomeMemberFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
