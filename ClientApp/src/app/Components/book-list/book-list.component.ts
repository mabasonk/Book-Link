import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  columns: any = [
    { title: 'id'},
    {title: 'Title', key: 'title'},
    {title: 'Author', key: 'author'},
    {title: 'Year Published', key: 'yearPublished'}
  ];
  booksList: any
  booksApi: string = '/api/books';
  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.getBookList();
  }

  getBookList(){
    this.httpClient.get(this.booksApi)
        .subscribe(response=> {
          this.booksList = response;
        console.log(response);
     })
  }
  deleteBook(id){
    this.httpClient.delete(this.booksApi+'/'+ id)
        .subscribe(response=> {
          console.log(response);
        })
  }

}
