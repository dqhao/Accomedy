import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PostService } from '../services/post.service';


@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.css']
})
export class PostDetailComponent implements OnInit {

  constructor(private _postService: PostService, private router: Router) { }

  ngOnInit(): void {
    
  }

  // postDetails(id_post: number){
  //   this._postService.postDetails(id_post)
  //   .subscribe
  //   (
  //     data =>
  //     {
  //       this.lstposts = data;
  //     }
  //   );
}
