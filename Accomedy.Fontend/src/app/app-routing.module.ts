import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PostDetailComponent } from './post/post-detail/post-detail.component';
import { PostListComponent } from './post/post-list/post-list.component';



const routes: Routes = [
  {path :'', redirectTo:'post-list', pathMatch:'full'},
  {path: 'post-detail/:post_id', component: PostDetailComponent},
  {path:'post-list',component : PostListComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'login',component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }