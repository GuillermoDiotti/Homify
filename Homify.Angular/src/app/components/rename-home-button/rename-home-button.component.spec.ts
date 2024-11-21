import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RenameHomeButtonComponent } from './rename-home-button.component';

describe('RenameHomeButtonComponent', () => {
  let component: RenameHomeButtonComponent;
  let fixture: ComponentFixture<RenameHomeButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RenameHomeButtonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RenameHomeButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
