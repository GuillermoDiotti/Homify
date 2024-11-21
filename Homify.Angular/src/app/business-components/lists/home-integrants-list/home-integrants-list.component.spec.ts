import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeIntegrantsListComponent } from './home-integrants-list.component';

describe('HomeIntegrantsListComponent', () => {
  let component: HomeIntegrantsListComponent;
  let fixture: ComponentFixture<HomeIntegrantsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomeIntegrantsListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomeIntegrantsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
