import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberHomeListComponent } from './member-home-list.component';

describe('MemberHomeListComponent', () => {
  let component: MemberHomeListComponent;
  let fixture: ComponentFixture<MemberHomeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MemberHomeListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MemberHomeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
