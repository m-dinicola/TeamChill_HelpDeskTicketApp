import { ActivatedRoute } from '@angular/router';
import { CommentService } from './../services/comment.service';
import { Component, Input, OnInit } from '@angular/core';
import { Logger } from '../services/logger.service';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css'],
  providers: [Logger, CommentService]
})
export class CommentsComponent implements OnInit {
  @Input() ticket:number;
  comments:Comment[];
  constructor(private logger:Logger, private commentService:CommentService, private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.commentService.getComments(this.ticket).subscribe(data=> this.comments = data);
    if(this.comments){
      this.logger.log(`Printed ${this.comments.length} comment(s) for given ticket #${this.ticket}`);
    }
    else {
      this.logger.warn(`No comments were found for ticket #${this.ticket}`);
    }
  }

}
