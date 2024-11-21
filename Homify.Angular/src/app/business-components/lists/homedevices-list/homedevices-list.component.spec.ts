import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomedevicesListComponent } from './homedevices-list.component';

describe('HomedevicesListComponent', () => {
  let component: HomedevicesListComponent;
  let fixture: ComponentFixture<HomedevicesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HomedevicesListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomedevicesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
