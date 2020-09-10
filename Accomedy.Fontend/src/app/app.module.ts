import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { NgSelectModule } from '@ng-select/ng-select';
import {PostService} from './post/services/post.service';
import { FormsModule } from '@angular/forms';
import {UserService} from './user/services/user.service';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { PostListComponent } from './post/post-list/post-list.component';
import { FooterComponent } from './footer/footer.component';
import { PostDetailComponent } from './post/post-detail/post-detail.component';
import { RegisterComponent } from './user/register/register.component';


@NgModule({
  declarations: [
    AppComponent,
    PostListComponent,
    TopBarComponent,
    FooterComponent,
    PostDetailComponent,
    RegisterComponent
   
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgSelectModule,
    FormsModule
  ],
  providers: [PostService, UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
