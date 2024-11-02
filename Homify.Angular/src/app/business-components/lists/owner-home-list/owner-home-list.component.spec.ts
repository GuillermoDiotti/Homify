import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerHomeListComponent } from './owner-home-list.component';

describe('OwnerHomeListComponent', () => {
  let component: OwnerHomeListComponent;
  let fixture: ComponentFixture<OwnerHomeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OwnerHomeListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OwnerHomeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
