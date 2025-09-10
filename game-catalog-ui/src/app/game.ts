export enum Platform {
  PC = 0,
  PlayStation = 1,
  Xbox = 2,
  Switch = 3
}

export interface Game {
  id: number;
  title: string;
  platform: number;
  genre: string;
  price: number;
  releaseDate: string | null;
}