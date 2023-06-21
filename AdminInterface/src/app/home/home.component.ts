import { Component, OnInit } from '@angular/core';
import { Category } from '../_models/category';
import { CategoryService } from '../_services/category.service';
import { PostService } from '../_services/post.service';
import { Post } from '../_models/post';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
   
  categories: Category[] = [];
  posts: Post[] = [];

  /**
   *
   */
  constructor(private categoryService: CategoryService, private postService: PostService, private router: Router) {

  }

  ngOnInit(): void {
    this.LoadCategories();
    this.LoadPosts();
    console.log(this.categories);
  }


  LoadCategories(){
      this.categoryService.getCategories().subscribe({
        next : categories => this.categories = categories
    })
  }

  LoadPosts(){
    this.postService.getPosts().subscribe({
      next : posts => this.posts = posts
    })
  }

}
