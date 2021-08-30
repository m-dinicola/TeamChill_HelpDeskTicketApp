import { BookmarkService } from './../services/bookmark.service';
import { Component, Input, OnInit } from '@angular/core';
import { Logger } from '../services/logger.service';

@Component({
  selector: 'app-bookmark-toggle',
  templateUrl: './bookmark-toggle.component.html',
  styleUrls: ['./bookmark-toggle.component.css']
})
export class BookmarkToggleComponent implements OnInit {
  @Input() user:string;
  @Input() ticket:number;
  state:boolean;
  bookmarks:Bookmark[];
  constructor(private bookmarkService:BookmarkService, private logger:Logger) { }

  ngOnInit(): void {
    this.bookmarkService.getBookmarks(this.user).subscribe(data => this.bookmarks=data);
    if(this.bookmarks.filter(x=>x.ticketId==this.ticket)){
      this.state = true;
      return;
    }
    this.state = false;
  }

  toggleBookmark():void{
    if(this.state){
      this.bookmarkService.removeBookmark(this.user,this.ticket).subscribe();
      this.logger.log(`Ticket #${this.ticket} has been removed from ${this.user}'s bookmarks.`);
      this.state = false;
    }
    this.bookmarkService.setBookmark(this.user,this.ticket).subscribe();
    this.logger.log(`Ticket #${this.ticket} has been added to ${this.user}'s bookmarks.`);
    this.state = true;
  }

}
