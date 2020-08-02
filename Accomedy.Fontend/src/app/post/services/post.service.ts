import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Post } from '../models/Post';
import { SearchResultModel } from '../models/SearchResultModel';
import { HttpHeaders } from '@angular/common/http';
import { NgAnalyzeModulesHost } from '@angular/compiler';


@Injectable()
export class PostService {

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  getposts(searchFilter: any) {
    return this.http.post<SearchResultModel>('https://localhost:44382/api/posts/search-result', searchFilter, this.httpOptions);
  }

  onSearchSubmit(searchFilter: any) {
    return this.http.post<SearchResultModel>('https://localhost:44382/api/posts/search-result', searchFilter, this.httpOptions);
  }

  postDetails(id_post: number) {
    return this.http.get("https://localhost:44382/api/posts/get-detail?postID=" + id_post);
  }



}