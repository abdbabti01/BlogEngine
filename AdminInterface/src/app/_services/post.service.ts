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
  post: Post | undefined

  constructor(private http: HttpClient) {}

  getPosts(){
    if(this.posts.length > 0) return of(this.posts);
    return this.http.get<Post[]>(this.baseurl + 'posts').pipe(
      map(posts => {
        this.posts = posts
        return posts;
      }))
  }

  getPost(id: string){

    //const post = this.posts.find(x => x.title== id);
    //if(post) return of(post);
    return this.http.get<Post>(this.baseurl + 'posts/' + id).pipe(
      map(post => {
        this.post = post
        return post;
      }))
  }


  add(model: any){   
    return this.http.post<Post>(this.baseurl + 'posts/addPost', model).pipe(
      map((response: Post) => {
        const post = response;
        this.posts = []; 
        if(post){
          localStorage.setItem('user', JSON.stringify(post));
        }
      })
    )
  }

  edit(model: any){    
    return this.http.put<Post>(this.baseurl + 'posts/updatePost', model).pipe(
      map((response: Post) => {
        const cat = response;
        this.posts = []; 
        if(cat){
          localStorage.setItem('user', JSON.stringify(cat));
        }
      })
    )
  }



}
