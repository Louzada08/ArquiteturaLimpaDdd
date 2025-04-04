import { Component, Input } from '@angular/core';
import { AppComponent } from "../../app.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [AppComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss' 
})
export class HomeComponent {
 @Input() teste = 'Valr boleano - Louzada';
 teste2 = 'Alana Ana Julia Arthur';
}



 