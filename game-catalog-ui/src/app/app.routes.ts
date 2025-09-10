import { Routes } from '@angular/router';
import { GameListComponent } from './game-list/game-list.component';
import { GameEditComponent } from './game-edit/game-edit.component';

export const routes: Routes = [
  { path: '', redirectTo: 'games', pathMatch: 'full' },
  { path: 'games', component: GameListComponent },
  { path: 'edit/:id', component: GameEditComponent },
  { path: '**', redirectTo: 'games' }
];