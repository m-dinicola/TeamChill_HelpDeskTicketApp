import { Logger } from '../services/logger.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page-not-found',
  templateUrl: './page-not-found.component.html',
  styleUrls: ['./page-not-found.component.css'],
  providers: [Logger]
})
export class PageNotFoundComponent implements OnInit {

  constructor(private logger: Logger) {

   }

  ngOnInit(): void {
    this.logger.error("The user tried to access a url that doesn't have a page.");

  }

}
