import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateMembersPermissionsComponent } from './update-members-permissions.component';

describe('UpdateMembersPermissionsComponent', () => {
  let component: UpdateMembersPermissionsComponent;
  let fixture: ComponentFixture<UpdateMembersPermissionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateMembersPermissionsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateMembersPermissionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
