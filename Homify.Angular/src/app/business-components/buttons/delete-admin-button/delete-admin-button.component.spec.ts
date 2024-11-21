import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteAdminButtonComponent } from './delete-admin-button.component';

describe('DeleteAdminButtonComponent', () => {
  let component: DeleteAdminButtonComponent;
  let fixture: ComponentFixture<DeleteAdminButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeleteAdminButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DeleteAdminButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
