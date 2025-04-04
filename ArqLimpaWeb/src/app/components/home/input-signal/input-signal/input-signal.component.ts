import { Component, input } from '@angular/core';

@Component({
  selector: 'app-signal',
  standalone: true,
  imports: [],
  template: '<span>{{ label() }} </span>',
})
export class InputSignalComponent {
  label = input('Vilma Gostosona')
}

