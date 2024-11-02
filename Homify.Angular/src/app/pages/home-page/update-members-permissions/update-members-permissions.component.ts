import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-update-members-permissions',
  templateUrl: './update-members-permissions.component.html',
  styleUrl: './update-members-permissions.component.css'
})
export class UpdateMembersPermissionsComponent {
  @Input() selectedHomeId: string | null = null;
  onHomeSelected(id: string) { this.selectedHomeId = id; }
}
