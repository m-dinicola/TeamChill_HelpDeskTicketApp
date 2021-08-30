import { FormsModule } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BookmarkService } from './../services/bookmark.service';
import { Component, Input, OnInit } from '@angular/core';
import { Logger } from '../services/logger.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-bookmarks',
  templateUrl: './bookmarks.component.html',
  styleUrls: ['./bookmarks.component.css'],
  providers: [BookmarkService, Logger]
})

export class BookmarksComponent implements OnInit {
  user:string;
  bookmarks:Bookmark[];
  constructor(private bookmarkService:BookmarkService, private route:ActivatedRoute, private logger:Logger) { }

  ngOnInit(): void {
    this.user = this.route.snapshot.paramMap.get("user");
    this.bookmarkService.getBookmarks(this.user).subscribe(data => this.bookmarks=data);
    if(this.bookmarks){
      this.logger.log(`Printed ${this.bookmarks.length} bookmarks for ${this.user}.`);
      return;
    }
    this.logger.warn(`No bookmarks were found for ${this.user}.`)

  }



}
