import { NgIf, DOCUMENT, CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NgIf, CommonModule],
  providers: [AuthService],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  constructor(@Inject(DOCUMENT) public document: Document, public auth: AuthService) {}
}
