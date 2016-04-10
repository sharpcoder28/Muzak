System.register(['angular2/core', 'angular2/router', './track.service'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, router_1, track_service_1;
    var TrackAddComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (track_service_1_1) {
                track_service_1 = track_service_1_1;
            }],
        execute: function() {
            TrackAddComponent = (function () {
                function TrackAddComponent(_trackService, _routeParams) {
                    this._trackService = _trackService;
                    this._routeParams = _routeParams;
                    this.track = {
                        id: 0,
                        title: '',
                        artists: '',
                        remixers: '',
                        genre: ''
                    };
                }
                // ngOnInit() {
                //     let id = +this._routeParams.get('id');
                //     //this._heroService.getHero(id)
                //     //.then(hero => this.hero = hero);
                // }
                TrackAddComponent.prototype.save = function () {
                    var _this = this;
                    console.log("save");
                    this._trackService.addTrack(this.track)
                        .subscribe(function (track) { return _this.tracks.push(track); }, function (error) { return _this.errorMessage = error; });
                };
                TrackAddComponent.prototype.addTrack = function (track) {
                    var _this = this;
                    //if (!name) {return;}
                    this._trackService.addTrack(track)
                        .subscribe(function (track) { return _this.tracks.push(track); }, function (error) { return _this.errorMessage = error; });
                };
                TrackAddComponent = __decorate([
                    core_1.Component({
                        selector: 'track-add',
                        //inputs: ['hero'],
                        templateUrl: 'app/track/track-add.component.html',
                        styleUrls: ['app/hero-detail.component.css']
                    }), 
                    __metadata('design:paramtypes', [track_service_1.TrackService, router_1.RouteParams])
                ], TrackAddComponent);
                return TrackAddComponent;
            })();
            exports_1("TrackAddComponent", TrackAddComponent);
        }
    }
});
//# sourceMappingURL=track-add.component.js.map