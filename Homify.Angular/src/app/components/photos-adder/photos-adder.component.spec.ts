import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhotosAdderComponent } from './photos-adder.component';

describe('PhotosAdderComponent', () => {
  let component: PhotosAdderComponent;
  let fixture: ComponentFixture<PhotosAdderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PhotosAdderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PhotosAdderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
