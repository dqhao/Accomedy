import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { PostService } from '../services/post.service';
import { Post } from '../models/Post';


@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.css']
})
export class PostDetailComponent implements OnInit {

  post_id: string;
  post: any;

  constructor(
    private _postService: PostService,
    private route: ActivatedRoute,
    private router: Router
  )
  {
    this.post_id = this.route.snapshot.paramMap.get('post_id');
  }

  ngOnInit() {
    this._postService.postDetails(this.post_id)
    .subscribe
      (
        data => {
          this.post = data;
        }
      );
  }

}
