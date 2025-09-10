import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Game } from './game';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private apiUrl = 'http://localhost:5177/api/games'; // <-- adjust port if needed

  constructor(private http: HttpClient) {}

  getGames(): Observable<Game[]> {
    return this.http.get<Game[]>(this.apiUrl);
  }

  getGame(id: number): Observable<Game> {
    return this.http.get<Game>(`${this.apiUrl}/${id}`);
  }

  updateGame(game: Game): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${game.id}`, game);
  }
}
