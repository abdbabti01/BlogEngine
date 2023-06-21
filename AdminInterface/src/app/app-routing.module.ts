import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCategoryComponent } from './add-category/add-category.component';
import { HomeComponent } from './home/home.component';
import { AddPostComponent } from './add-post/add-post.component';

const routes: Routes = [

{path: '', component: HomeComponent},
{path: 'addcategory', component: AddCategoryComponent},
{path: 'addpost', component: AddPostComponent},
{path: '**', component: HomeComponent, pathMatch: 'full'},];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
