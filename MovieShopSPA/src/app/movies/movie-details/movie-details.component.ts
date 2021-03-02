import { Component, Input, OnInit } from '@angular/core';
import { MovieService } from 'src/app/core/services/movie.service';
import { MovieCard } from 'src/app/shared/models/movie-card';
import { MovieDetail } from 'src/app/shared/models/movie-details';
import {ActivatedRoute} from '@angular/router'

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  constructor(private movieService:MovieService, private router : ActivatedRoute) { }

  movie!: MovieDetail;
  data: any;
  ngOnInit(): void {
    console.log(this.router.snapshot.params.id)
    this.data = this.router.snapshot.params.id;
    this.movieService.getMovieById(this.data).subscribe(
      m => {
        this.movie = m;
        console.log(this.movie);
      }
    );
  }

}
