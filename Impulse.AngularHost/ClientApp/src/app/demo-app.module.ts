import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { DemoAppComponent } from './demo-app/demo-app.component';
import { DemoNavMenuComponent } from './demo-nav-menu/demo-nav-menu.component';
import { DemoHomeComponent } from './demo-home/demo-home.component';
import { DemoNewsComponent } from './demo-news/demo-news.component';
import { DemoContactComponent } from './demo-contact/demo-contact.component';
import { DemoAboutComponent } from './demo-about/demo-about.component';

@NgModule({
  declarations: [
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    DemoAppComponent,
    DemoNavMenuComponent,
    DemoHomeComponent,
    DemoNewsComponent,
    DemoContactComponent,
    DemoAboutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: DemoHomeComponent, pathMatch: 'full' },
      { path: 'news', component: DemoNewsComponent, pathMatch: 'full' },
      { path: 'contact', component: DemoContactComponent, pathMatch: 'full' },
      { path: 'about', component: DemoAboutComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [DemoAppComponent]
})
export class DemoAppModule { }
