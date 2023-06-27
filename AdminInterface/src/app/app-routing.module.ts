import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCategoryComponent } from './add-category/add-category.component';
import { HomeComponent } from './home/home.component';
import { AddPostComponent } from './add-post/add-post.component';
import { EditCategoryComponent } from './edit-category/edit-category.component';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { EditPostComponent } from './edit-post/edit-post.component';
import { PreventUnsavedChanges2Guard } from './_guards/prevent-unsaved-changes2.guard';

const routes: Routes = [

{path: '', component: HomeComponent},
{path: 'addcategory', component: AddCategoryComponent},
{path: 'editcategory/:id', component: EditCategoryComponent, canDeactivate: [PreventUnsavedChangesGuard]},
{path: 'editpost/:id', component: EditPostComponent, canDeactivate: [PreventUnsavedChanges2Guard]},
{path: 'addpost', component: AddPostComponent},
{path: '**', component: HomeComponent, pathMatch: 'full'},];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
