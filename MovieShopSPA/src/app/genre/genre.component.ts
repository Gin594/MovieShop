import { Component, OnInit } from '@angular/core';
import { GenreService } from '../core/services/genre.service';
import { Genre } from '../shared/models/genre';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css']
})
export class GenreComponent implements OnInit {
  // this property will be available to view so that it can use to 
  // display data
  // this property will be available to view so that it can use to 
  // display data
  genres: Genre[] = [];
  constructor(private genreService: GenreService) { }

  ngOnChanges(){
    console.log("Inside ngOnChanges method")
  }

  // this where we call our API to get the data
  ngOnInit() {
    console.log("Inside ngOnInit method")
    this.genreService.getAllGenres().subscribe(
      g => {
        this.genres = g;
        console.log('genres')
      }
    );
  }
  ngOnDestroy(){
    console.log("Inside ngOnDestroy method")
  }

}
