import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AddCategoryComponent } from './add-category/add-category.component';
import { AddPostComponent } from './add-post/add-post.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { NgxSpinnerModule } from 'ngx-spinner';
import { EditCategoryComponent } from './edit-category/edit-category.component';
import { DatePickerComponent } from './_forms/date-picker/date-picker.component';
import { EditPostComponent } from './edit-post/edit-post.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddCategoryComponent,
    AddPostComponent,
    NavbarComponent,
    EditCategoryComponent,
    DatePickerComponent,
    EditPostComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    BsDatepickerModule.forRoot(),
    BrowserAnimationsModule,
    NgxSpinnerModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass : LoadingInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
