import { Component, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PostService } from '../_services/post.service';
import { NgForm } from '@angular/forms';
import { CategoryService } from '../_services/category.service';

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.css']
})
export class EditPostComponent {
  @ViewChild('editform') editform: NgForm | undefined;

  constructor(private activeRoute: ActivatedRoute, private router: Router, 
    private postService: PostService,private toastr: ToastrService, private categoryService: CategoryService){}
  
  categories: any
  post: any;
  title: any;
  categoryId: any;
  content: any;

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe({
      next : categories => this.categories = categories
    })
    const id = this.activeRoute.snapshot.paramMap.get('id');
    if(!id) return;

    this.postService.getPost(id).subscribe({
      next : post => {
        this.post = post;
        this.title = post.title;
        this.categoryId = post.categoryId;
        this.content = post.Content;
      }
    })

    
  }

  edit(){

    this.post.title = this.title;
    this.post.categoryId = this.categoryId;
    this.post.Content = this.content;
    
    this.postService.edit(this.post).subscribe({
      next : response => { // don't forget to delete response because we're not using it anymore
        // this.router.navigate(["/home"])
        this.toastr.success('Category updated successfully');
        this.editform?.reset(this.post)
      },
      error: error => {
        if(error.error.errors){
          this.toastr.error(error.error.errors.Title)
        }else{
          this.toastr.error(error.error)
        }
      }
    })
  }

}
