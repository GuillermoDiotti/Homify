import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateMembersPermissionsFormComponent } from './update-members-permissions-form.component';

describe('UpdateMembersPermissionsFormComponent', () => {
  let component: UpdateMembersPermissionsFormComponent;
  let fixture: ComponentFixture<UpdateMembersPermissionsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateMembersPermissionsFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateMembersPermissionsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
