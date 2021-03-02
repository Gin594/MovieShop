export interface MovieDetail {
    id: number;
    title: string;
    overview: string;
    tagline: string;
    budget: number;
    revenue: number;
    imdbUrl: string;
    tmdbUrl?: any;
    posterUrl: string;
    backdropUrl: string;
    originalLanguage?: any;
    releaseDate: string;
    runTime: number;
    price: number;
    rating: number;
    genres: Genre[];
    casts: Cast[];
    reviews: any[];
  }
  
  interface Cast {
    id: number;
    name: string;
    gender?: any;
    tmdbUrl?: any;
    profilePath: string;
    character: string;
  }
  
  interface Genre {
    id: number;
    name: string;
  }