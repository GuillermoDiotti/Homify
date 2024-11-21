import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-add-member',
  templateUrl: './add-member.component.html',
  styleUrl: './add-member.component.css'
})
export class AddMemberComponent {
  @Input() selectedHomeId: string | null = null;
  onHomeSelected(id: string) { this.selectedHomeId = id; }
}
