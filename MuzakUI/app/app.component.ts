import { Component }       from 'angular2/core';
import { HeroService }     from './hero.service';
import { TrackService }    from './track/track.service';
import { ArtistService }    from './artist/artist.service';
import { HeroesComponent } from './heroes.component';
import { HeroDetailComponent } from './hero-detail.component'
import { DashboardComponent } from './dashboard.component';
import { RouteConfig, ROUTER_DIRECTIVES, ROUTER_PROVIDERS } from 'angular2/router';
import { TrackAddComponent } from './track/track-add.component';
import { HTTP_PROVIDERS}    from 'angular2/http';
import { ArtistCreateComponent }    from './artist/artist-add.component';

@RouteConfig([
    {
        path: '/dashboard',
        name: 'Dashboard',
        component: DashboardComponent,
        useAsDefault: true
    },
    {
        path: '/heroes',
        name: 'Heroes',
        component: HeroesComponent
    },
    {
        path: '/detail/:id',
        name: 'HeroDetail',
        component: HeroDetailComponent
    },
    {
        path: '/trackadd',
        name: 'TrackAdd',
        component: TrackAddComponent
    },
    {
        path: '/search',
        name: 'Search',
        component: TrackAddComponent
    },
    {
        path: '/artistadd',
        name: 'ArtistCreate',
        component: ArtistCreateComponent
    },
])

@Component({
    selector: 'my-app',
    template: `
        <h1>{{title}}</h1>
        <nav>
            <a [routerLink]="['Dashboard']">Dashboard</a>
            <a [routerLink]="['Heroes']">Heroes</a>
            <a [routerLink]="['TrackAdd']">Add Track</a>
            <a [routerLink]="['Search']">Search</a>
            <a [routerLink]="['ArtistCreate']">Add Artist</a>
        </nav>
        <router-outlet></router-outlet>
    `,
    styleUrls: ['app/app.component.css'],
    directives: [ROUTER_DIRECTIVES],
    providers: [
        ROUTER_PROVIDERS,
        HeroService,
        TrackService,
        HTTP_PROVIDERS,
        ArtistService
    ]
})
export class AppComponent {
    title = 'My Playlist';
}

