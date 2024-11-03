import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomedevicesComponent } from './homedevices.component';

describe('HomedevicesComponent', () => {
  let component: HomedevicesComponent;
  let fixture: ComponentFixture<HomedevicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomedevicesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomedevicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
