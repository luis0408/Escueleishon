import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { getBaseUrl } from '../../main';

import { ImportsModule } from '../imports';


@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css'],
  standalone: true,
  imports: [ImportsModule]

})
export class AddStudentComponent{


  constructor(private http: HttpClient) {
  }

  public student: Student = new Student();

  public students: any = [];

  public carrers: any;
  public genters: any;  
  public semesters: any;
  public date: any;
  ngOnInit() {
    this.GetCatalogs();


  }
 

  public GetCatalogs() {
    let ctx = this;

    ctx.http.post(getBaseUrl() + "/Student/getCatalogs", {}).subscribe({
      next: data => {
        ctx.carrers = (data as any).Entity[0];
        ctx.semesters = (data as any).Entity[1];
        ctx.genters = (data as any).Entity[2];

        ctx.students = (data as any).Entity[3]; 
    },
      error: error => {
        console.log(error);
      }

    });

  }

  public AddStudents() {
    let ctx = this;

    let header = {'Content-Type':'application/json'}
    ctx.http.post(getBaseUrl() + "/Student/AddStudent", JSON.stringify(ctx.student), {headers:header}).subscribe({
      next: data => {
        if ((data as any).code == "200") {
          ctx.students = (data as any).Entity[0];

        }
        else {
          
        }
      },
      error: error => {
        console.log(error);
      }

    });

  }

}

class Student
{
   noControl       :string='';
   idCarrera       :string='';
   idSemestre      :string='';
   idGenero        :string='';
   nombre          :string='';
   apellidoPaterno :string='';
   apellidoMaterno :string='';
   edad            :string='';
   CURP            :string='';
   email           :string='';
   telefono        :string='';
   fechaNac        :string='';
  estatus: string = '';
}
