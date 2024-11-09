import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-pagination',
  standalone: true,
  imports: [],
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.css'
})
export class PaginationComponent {
	@Input() limit: number = 0;
  @Input() offset: number = 0;
  @Output() limitChange = new EventEmitter<number>();
  @Output() offsetChange = new EventEmitter<number>();

  onLimitChange(event: Event): void {
    const newLimit = Math.max(0, +(event.target as HTMLInputElement).value);
    this.limitChange.emit(newLimit);
  }

  onOffsetChange(event: Event): void {
    const newOffset = Math.max(0, +(event.target as HTMLInputElement).value);
    this.offsetChange.emit(newOffset);
  }
}
