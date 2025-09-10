import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { GameService } from '../game.service';
import { Game, Platform } from '../game';

@Component({
  selector: 'app-game-edit',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './game-edit.component.html'
})
export class GameEditComponent implements OnInit {
  game: Game = { id: 0, title: '', genre: '', platform: 0, price: 0, releaseDate: null };

  // prepare enum entries for dropdown
  platformOptions = [
    { value: Platform.PC, label: 'PC' },
    { value: Platform.PlayStation, label: 'PlayStation' },
    { value: Platform.Xbox, label: 'Xbox' },
    { value: Platform.Switch, label: 'Switch' }
  ];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private service: GameService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.service.getGame(id).subscribe(data => this.game = data);
  }

  save(): void {
    this.service.updateGame(this.game).subscribe(() => this.router.navigate(['/games']));
  }
}