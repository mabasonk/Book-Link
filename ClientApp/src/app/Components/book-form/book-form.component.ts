import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})

export class BookFormComponent implements OnInit {
  book: any = {
    id:0, 
    title: '', 
    author: '',
    yearPublished: 0
  }
  yearPublishedDates: any
  booksList: any

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.getYearPublishedDates();
  }
  submit(){
    this.httpClient.post('/api/books',this.book)
        .subscribe(response=> {
          console.log(response);

    });
    //this.router.navigate(['/books-list/'])
  }
  getYearPublishedDates(){
    return this.yearPublishedDates = ['2015', '2016', '2017', '2018', '2019' ]
      
   }

}
