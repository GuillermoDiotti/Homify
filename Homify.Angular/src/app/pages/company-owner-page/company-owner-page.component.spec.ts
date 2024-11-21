import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyOwnerPageComponent } from './company-owner-page.component';

describe('CompanyOwnerPageComponent', () => {
  let component: CompanyOwnerPageComponent;
  let fixture: ComponentFixture<CompanyOwnerPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanyOwnerPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompanyOwnerPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
