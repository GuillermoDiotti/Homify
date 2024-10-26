import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeOwnerPageComponent } from './home-owner-page.component';

describe('HomeOwnerPageComponent', () => {
  let component: HomeOwnerPageComponent;
  let fixture: ComponentFixture<HomeOwnerPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeOwnerPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomeOwnerPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
