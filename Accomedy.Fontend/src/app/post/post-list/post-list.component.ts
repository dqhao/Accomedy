import { Component, OnInit } from '@angular/core';
import { PostService } from '../services/post.service';
import { Post } from '../models/Post';
import { SearchResultModel } from '../models/SearchResultModel';
import { Router} from '@angular/router';


@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {

  prices = [
    { id: 5000, name: 'Smaller than $5,000' },
    { id: 10000, name: 'Smaller than $10,000' },
    { id: 50000, name: 'Smaller than $50,000' },
    { id: 1000000, name: 'Smaller than $1,000,000' },
    { id: 2000000, name: 'Smaller than $2,000,000' }
  ];

  post: Post = new Post();
  searchFilter: any;


  constructor(private _postService: PostService, private router: Router) {

  }

  lstposts: any = new SearchResultModel();

  // = [{"postId":1,"title":"Phong tro gia re 1","details":"phong rong 12x12, o duoc 4 nguoi, gio giac tu do","photos":"abc","price":20.5,"address":"quang trung, go vap","ownerId":2,"guestId":0},{"postId":2,"title":"Phong tro gia re 2","details":"phong rong 15x13, o duoc 3 nguoi, 10h dong cua","photos":"abc","price":12.01,"address":"cau ong lanh, quan 4","ownerId":3,"guestId":1}];

  ngOnInit() {
    this.post.price = { id: 2000000, name: 'Smaller than $2,000,000' };
    let filter = this.convertFilter(this.post);
    this.searchFilter = {
      "Criterias": filter,
      "sortedBy": "TITLE",
      "isDescSorting": false,
      "pageNumber": 1,
      "pageCount": 9
    }
    this._postService.getposts(this.searchFilter)
      .subscribe
      (
        data => {
          this.lstposts = data;
        }
      );
  }

  onSearchSubmit(post: any) {
    let filter = this.convertFilter(post);
    this.searchFilter = {
      "Criterias": filter,
      "sortedBy": "TITLE",
      "isDescSorting": false,
      "pageNumber": 1,
      "pageCount": 9
    }
    this._postService.getposts(this.searchFilter)
      .subscribe
      (
        data => {
          this.lstposts = data;
        }
      );
  }

  onDetailSubmit(post_id: any){
    this.router.navigate([`/post-detail/${post_id}`]);
  }

  convertFilter(obj: any) {
    return {
      title: obj.title,
      price: this.getObjKeyData(obj.price),
      address: obj.address
    };
  }

  getObjKeyData(rs: any) {
    if (rs) {
      return rs.id;
    }
    return null;
  }

}


