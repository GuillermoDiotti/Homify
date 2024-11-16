import { Component, Input } from '@angular/core';
import { InputComponent } from '../input/input.component';
import { ButtonComponent } from '../button/button.component';

@Component({
  selector: 'app-photos-adder',
  standalone: true,
  imports: [InputComponent, ButtonComponent],
  templateUrl: './photos-adder.component.html',
  styleUrl: './photos-adder.component.css',
})
export class PhotosAdderComponent {
  @Input() photos: string[] = [];
  inputValue = '';

  onSubmit() {
    if (this.inputValue.length > 4 && !this.photos.includes(this.inputValue)) {
      this.photos.push(this.inputValue);
			this.inputValue = '';
    }
  }

	handleChange(value: string) {
		this.inputValue = value;
	}
}
