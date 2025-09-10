import { Component, OnInit, NgZone } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { GameService } from '../game.service';
import { Game, Platform } from '../game';

@Component({
  selector: 'app-game-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './game-list.component.html'
})
export class GameListComponent implements OnInit {
  games: Game[] = [];
  loading = true;

  constructor(
    private service: GameService,
    private router: Router,
    private ngZone: NgZone
  ) {}

  ngOnInit(): void {
    this.loadGames();
  }

  loadGames(): void {
    this.loading = true;
    this.service.getGames().subscribe({
      next: data => {
        console.log('Loaded games from API:', data); // check devtools -> Console
        // ensure change detection runs inside Angular zone
        this.ngZone.run(() => {
          this.games = data || [];
          this.loading = false;
        });
      },
      error: err => {
        console.error('Failed to load games', err);
        this.ngZone.run(() => {
          this.games = [];
          this.loading = false;
        });
      }
    });
  }

  editGame(id: number) {
    this.router.navigate(['/edit', id]);
  }

  platformName(value?: number): string {
    switch (value) {
      case Platform.PC: return 'PC';
      case Platform.PlayStation: return 'PlayStation';
      case Platform.Xbox: return 'Xbox';
      case Platform.Switch: return 'Switch';
      default: return 'Unknown';
    }
  }
}