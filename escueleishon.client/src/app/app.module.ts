import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AddStudentComponent } from './add-student/add-student.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common'; 




@NgModule({
  declarations: [
    AppComponent,
    
    //AddStudentComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    CommonModule,

    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      
      { path: 'AddStudent', component: AddStudentComponent },
    ])
  ],

  providers: [BrowserModule, CommonModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
