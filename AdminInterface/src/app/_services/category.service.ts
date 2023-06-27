import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../_models/category';
import { map, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  baseurl = 'http://localhost:5115/api/';
  categories: Category[] = [];
  category: Category | undefined;

  constructor(private http: HttpClient) {}

  getCategories(){
    if(this.categories.length > 0) return of(this.categories); 
    return this.http.get<Category[]>(this.baseurl + 'categories').pipe(
      map(categories => {
        this.categories = categories
        return categories;
      })
    )
  }

  getCategory(title: string){
    const category = this.categories.find(x => x.title == title);
    if(category) return of(category);
    return this.http.get<Category>(this.baseurl + 'categories/' + title).pipe(
      map(category => {
        this.category = category
        return category;
      }))
  }

  add(model: any){   
    return this.http.post<Category>(this.baseurl + 'Categories/addCategory', model).pipe(
      map((response: Category) => {
        const cat = response;
        this.categories = []; 
        if(cat){
          localStorage.setItem('user', JSON.stringify(cat));
        }
      })
    )
  }


  edit(model: any){    
    return this.http.put<Category>(this.baseurl + 'Categories/updateCategory', model).pipe(
      map((response: Category) => {
        const cat = response;
        this.categories = []; 
        if(cat){
          localStorage.setItem('user', JSON.stringify(cat));
        }
      })
    )
  }

}
