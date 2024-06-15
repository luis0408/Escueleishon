import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { getBaseUrl } from '../../main';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css']

})
export class AddStudentComponent {

  constructor(private http: HttpClient) {

  }

  public carrers: any;
  public genters: any;
  public semesters: any;
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
    },
      error: error => {
        console.log(error);
      }

    });

  }

}
