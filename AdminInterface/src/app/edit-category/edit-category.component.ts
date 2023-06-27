import { Component, OnInit, ViewChild } from '@angular/core';
import { Category } from '../_models/category';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoryService } from '../_services/category.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit{
  @ViewChild('editform') editform: NgForm | undefined;

  constructor(private activeRoute: ActivatedRoute, private router: Router, 
    private categoryService: CategoryService,private toastr: ToastrService){}

  category: any;
  title: any;

  ngOnInit(): void {
    const title = this.activeRoute.snapshot.paramMap.get('id');
    if(!title) return;

    this.categoryService.getCategory(title).subscribe({
      next : category => {
        this.category = category;
        this.title = this.category.title
      }
    })

    
  }

  save(){

    this.category.title = this.title;
    
    this.categoryService.edit(this.category).subscribe({
      next : response => { // don't forget to delete response because we're not using it anymore
        // this.router.navigate(["/home"])
        this.toastr.success('Category updated successfully');
        this.editform?.reset(this.category)
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
