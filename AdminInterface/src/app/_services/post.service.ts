import { Injectable } from '@angular/core';
import { Post } from '../_models/post';
import { HttpClient } from '@angular/common/http';
import { map, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  baseurl = 'http://localhost:5115/api/';
  posts: Post[] = [];

  constructor(private http: HttpClient) {}

  getPosts(){
    if(this.posts.length > 0) return of(this.posts);
    return this.http.get<Post[]>(this.baseurl + 'posts').pipe(
      map(posts => {
        this.posts = posts
        return posts;
       }))
 }
}
