import {Component, input} from '@angular/core';
import {member} from '../../_models/member';
import {NgOptimizedImage} from '@angular/common';

@Component({
  selector: 'app-member-card',
  standalone: true,
    imports: [
        NgOptimizedImage
    ],
  templateUrl: './member-card.component.html',
  styleUrl: './member-card.component.css'
})
export class MemberCardComponent {
    member = input.required<member>();

}
