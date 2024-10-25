import { CommonModule } from '@angular/common';
import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-button',
  standalone: true,
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.css'],
  imports: [CommonModule]
})
export class ButtonComponent {
  @Input() backgroundColor: string = '#f3e5f5';
  @Input() color: string = '#000000';
  @Input() type: string = 'button';
  @Output() clicked = new EventEmitter<Event>();

  onClick() {
    this.clicked.emit();
  }
}
