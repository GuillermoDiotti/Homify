import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeMemberListComponent } from './home-member-list.component';

describe('HomeMemberListComponent', () => {
  let component: HomeMemberListComponent;
  let fixture: ComponentFixture<HomeMemberListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeMemberListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomeMemberListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
