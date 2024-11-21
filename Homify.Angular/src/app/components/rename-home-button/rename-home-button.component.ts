import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RenameHomeFormComponent } from '../../business-components/forms/rename-home-form/rename-home-form.component';
import { ButtonComponent } from '../button/button.component';

@Component({
  selector: 'app-rename-home-button',
  standalone: true,
  imports: [ButtonComponent],
  templateUrl: './rename-home-button.component.html',
  styleUrl: './rename-home-button.component.css'
})
export class RenameHomeButtonComponent {
	@Input() homeId: string = '';

	constructor(public dialog: MatDialog) {}

	openModal(): void {
    this.dialog.open(RenameHomeFormComponent, {
      data: { homeId: this.homeId }
    });
  }
}
