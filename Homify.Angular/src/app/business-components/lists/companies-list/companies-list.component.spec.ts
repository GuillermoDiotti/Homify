import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AccountsListComponent } from '../accounts-list/accounts-list.component';

describe('AccountsListComponent', () => {
  let component: AccountsListComponent;
  let fixture: ComponentFixture<AccountsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AccountsListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccountsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
