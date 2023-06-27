import { Component, OnChanges, OnInit } from '@angular/core';
import { CategoryService } from '../_services/category.service';
import { Category } from '../_models/category';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PostService } from '../_services/post.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent implements OnInit{

  model: any={}
  categories: any
  maxDate: Date = new Date();
  editform: FormGroup = new FormGroup({});

  constructor(private categoryService: CategoryService, private router: Router, 
    private toastr: ToastrService, private postService: PostService,private fb: FormBuilder){}



  ngOnInit(): void {
    this.categoryService.getCategories().subscribe({
      next : categories => this.categories = categories
    })
    this.initializeForm();
  }

  initializeForm() {
    this.editform = this.fb.group({
      dateOfPub: ['', Validators.required],
    });
  }

  


  add(){
    this.model.PublicationDate = this.editform.controls['dateOfPub'].value
    this.postService.add(this.model).subscribe({
      next : response => { // don't forget to delete response because we're not using it anymore
        this.router.navigateByUrl("/home")
      },
      error: error => {
        if(error.error.errors){
          this.toastr.error(error.error.errors.Title)
        }else{
          this.toastr.error(error.error)
        }
      }
    })
    console.log(this.model)
  }



}
