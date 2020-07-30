import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import {Post} from '../models/Post'


@Injectable()
export class PostService {
    constructor(private http: HttpClient) { }

    getposts() {
        // return this.http.get
         return this.http.get("http://localhost:8080/api/post/get-posts");
        // this.http.post<Post>('https://localhost:44382/api/posts/search-result', { title: 'Angular POST Request Example' }).subscribe(data => {
        //     this.postId = data.id;
        // })
    }

    onSearchSubmit(post:Post){
        return this.http.get("http://localhost:8080/api/post/search-results?keywords=" + post.keywords + "&address=" + post.address + "&prices=" + post.price.id);
    }

    postDetails(id_post: number){
        return this.http.get("http://localhost:8080/api/post/get-details?id=" + id_post);
    }



}