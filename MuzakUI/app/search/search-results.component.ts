import { Component, OnInit } from 'angular2/core';

import { TrackResult } from './track-result';
import { HeroService } from '../hero.service';
import { Router } from 'angular2/router';

@Component({
  selector: 'search-results',
  templateUrl: 'app/dashboard.component.html',
  styleUrls: ['app/dashboard.component.css']
})

export class DashboardComponent implements OnInit {

    tracks: TrackResult[] = [];

    constructor(
        private _heroService: HeroService,
        private _router: Router) { }

    ngOnInit() {
        this._heroService.getHeroes()
        .then(tracks => this.tracks = tracks);
    }

    // gotoDetail(hero: Hero) {
    //     let link = ['HeroDetail', { id: hero.id }];
    //     this._router.navigate(link);
    // }
}