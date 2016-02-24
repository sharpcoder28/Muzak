System.register(['angular2/core', 'angular2/router', './hero.service'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, router_1, hero_service_1;
    var TrackAddComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (hero_service_1_1) {
                hero_service_1 = hero_service_1_1;
            }],
        execute: function() {
            TrackAddComponent = (function () {
                //hero: Hero;
                function TrackAddComponent(_heroService, _routeParams) {
                    this._heroService = _heroService;
                    this._routeParams = _routeParams;
                }
                TrackAddComponent.prototype.ngOnInit = function () {
                    var id = +this._routeParams.get('id');
                    //this._heroService.getHero(id)
                    //.then(hero => this.hero = hero);
                };
                TrackAddComponent.prototype.goBack = function () {
                    window.history.back();
                };
                TrackAddComponent = __decorate([
                    core_1.Component({
                        selector: 'track-add',
                        //inputs: ['hero'],
                        templateUrl: 'app/track-add.component.html',
                        styleUrls: ['app/hero-detail.component.css']
                    }), 
                    __metadata('design:paramtypes', [hero_service_1.HeroService, router_1.RouteParams])
                ], TrackAddComponent);
                return TrackAddComponent;
            })();
            exports_1("TrackAddComponent", TrackAddComponent);
        }
    }
});
//# sourceMappingURL=track-add.component.js.map