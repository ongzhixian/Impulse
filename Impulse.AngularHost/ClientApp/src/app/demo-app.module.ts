import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AppComponent } from './demo/app/app.component';
import { NavMenuComponent } from './demo/ui-components/nav-menu/nav-menu.component';
import { HomeComponent } from './demo/pages/home/home.component';
import { NewsComponent } from './demo/pages/news/news.component';
import { ContactComponent } from './demo/pages/contact/contact.component';
import { AboutComponent } from './demo/pages/about/about.component';

@NgModule({
  declarations: [
    CounterComponent,
    FetchDataComponent,
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    NewsComponent,
    ContactComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'news', component: NewsComponent, pathMatch: 'full' },
      { path: 'contact', component: ContactComponent, pathMatch: 'full' },
      { path: 'about', component: AboutComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class DemoAppModule { }
