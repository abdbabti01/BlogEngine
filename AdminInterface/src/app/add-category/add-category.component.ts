import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryService } from '../_services/category.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {

  constructor(private router: Router, private categoryService: CategoryService, private toastr: ToastrService) {
    
  }

  model: any={}

  add(){
    this.categoryService.add(this.model).subscribe({
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
  }


}
