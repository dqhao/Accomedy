import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PostDetailComponent } from './post/post-detail/post-detail.component';
import { PostListComponent } from './post/post-list/post-list.component';


const routes: Routes = [
  {path :'', redirectTo:'post-list', pathMatch:'full'},
  {path: 'postDetail/:postId', component: PostDetailComponent},
  {path:'post-list',component : PostListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
