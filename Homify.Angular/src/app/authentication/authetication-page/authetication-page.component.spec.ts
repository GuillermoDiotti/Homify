import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AutheticationPageComponent } from './authetication-page.component';

describe('AutheticationPageComponent', () => {
  let component: AutheticationPageComponent;
  let fixture: ComponentFixture<AutheticationPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AutheticationPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AutheticationPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
