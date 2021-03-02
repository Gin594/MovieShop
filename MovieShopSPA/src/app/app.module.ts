import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GenreComponent } from './genre/genre.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { FooterComponent } from './core/layout/footer/footer.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {HttpClientModule} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from '@angular/forms'

import { HomeComponent } from './home/home.component';
import { MoviesListComponent } from './movies/movies-list/movies-list.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { LoginComponent } from './auth/login/login.component';
import { SignUpComponent } from './auth/sign-up/sign-up.component';
import { FavoritesComponent } from './account/favorites/favorites.component';
import { PurchaseComponent } from './account/purchase/purchase.component';
import { CreateMovieComponent } from './admin/create-movie/create-movie.component';
import { CreateCastComponent } from './admin/create-cast/create-cast.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { MovieCardComponent } from './shared/components/movie-card/movie-card.component'

@NgModule({
  declarations: [
    AppComponent,
    GenreComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    MoviesListComponent,
    MovieDetailsComponent,
    LoginComponent,
    SignUpComponent,
    FavoritesComponent,
    PurchaseComponent,
    CreateMovieComponent,
    CreateCastComponent,
    NotFoundComponent,
    MovieCardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
