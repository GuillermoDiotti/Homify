import { Component, OnInit } from '@angular/core';
import { ButtonComponent } from '../../../components/button/button.component';
import { RoleService } from '../../../../backend/services/roles/Role.service';
import { APIError } from '../../../../interfaces/interfaces';
import { SuccessMessageComponent } from '../../../components/success-message/success-message.component';
import { ErrorMessageComponent } from '../../../components/error-message/error-message.component';
import { UpdateProfileFormComponent } from '../../forms/update-profile-form/update-profile-form.component';

@Component({
  selector: 'app-homeowner-button',
  standalone: true,
  imports: [
    ButtonComponent,
    SuccessMessageComponent,
    ErrorMessageComponent,
    UpdateProfileFormComponent,
  ],
  templateUrl: './homeowner-button.component.html',
  styleUrl: './homeowner-button.component.css',
})
export class HomeownerButtonComponent implements OnInit {
  errorMessage = '';
  successMessage = '';
  showForm = false;

  constructor(private readonly RoleService: RoleService) {}

  ngOnInit(): void {
    const roles =
      (JSON.parse(localStorage.getItem('roles') ?? '[]') as any[]) || [];
			console.log(roles)
    this.showForm = roles.some((x) => x == 'HOMEOWNER');
  }

  onClick() {
    this.errorMessage = '';
    this.successMessage = '';

    this.RoleService.addRoleToExistingUser().subscribe(
      (res) => {
				console.log(res)
        this.successMessage = 'New role added successfully';
        localStorage.setItem('roles', JSON.stringify(res.roles));
        const roles =
          (JSON.parse(localStorage.getItem('roles') ?? '[]') as any[]) || [];
        this.showForm = roles.some((x) => x == 'HOMEOWNER');
      },
      (err: APIError) => (this.errorMessage = err.error.message)
    );
  }
}
