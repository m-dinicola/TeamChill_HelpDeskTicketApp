import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HelpDeskComponent } from './help-desk/help-desk.component';
import { TicketComponent } from './ticket/ticket.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { CommentComponent } from './comment/comment.component';
import { CommentsComponent } from './comments/comments.component';
import { BookmarksComponent } from './bookmarks/bookmarks.component';
import { BookmarkToggleComponent } from './bookmark-toggle/bookmark-toggle.component';
import { ShortTicketComponent } from './short-ticket/short-ticket.component';

const appRoutes: Routes = [
  { path: '', redirectTo: 'helpdesk', pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'helpdesk', component: HelpDeskComponent },
  { path: 'helpdesk/:id', component: TicketComponent},
  { path: 'helpdesk/bookmarks/:user', component: BookmarksComponent},
  { path: 'helpdesk/comment/:ticket', component: CommentComponent},
  { path: '**', component: PageNotFoundComponent}
]


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    HelpDeskComponent,
    TicketComponent,
    PageNotFoundComponent,
    CommentComponent,
    CommentsComponent,
    BookmarksComponent,
    BookmarkToggleComponent,
    ShortTicketComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
