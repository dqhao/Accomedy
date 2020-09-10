import { Injectable, ɵConsole } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class UserService {
  

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  
register(user: Object):Observable<Object>{
  return this.http.post('https://localhost:44382/api/posts/search-result', user, this.httpOptions);
 }
checkLogin(username,password){
  var data = "username="+username+"&password="+password;
  return this.http.post('https://localhost:44382/api/posts/search-result', data, this.httpOptions);
 }

 
}
