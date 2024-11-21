import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RenameHomeFormComponent } from './rename-home-form.component';

describe('RenameHomeFormComponent', () => {
  let component: RenameHomeFormComponent;
  let fixture: ComponentFixture<RenameHomeFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RenameHomeFormComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RenameHomeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
