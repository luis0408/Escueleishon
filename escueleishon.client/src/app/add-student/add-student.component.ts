import { HttpClient } from '@angular/common/http';
import { getBaseUrl } from '../../main';
import { MatDatepickerModule } from '@angular/material/datepicker';
import {
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  Component,
  Inject,
  OnDestroy,
} from '@angular/core';
import { MatCalendar } from '@angular/material/datepicker';
import { DateAdapter, MAT_DATE_FORMATS, MatDateFormats } from '@angular/material/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,

})
export class AddStudentComponent<D> implements OnDestroy {
  private _destroyed = new Subject<void>();

  constructor(
    
    private _calendar: MatCalendar<D>,
    private _dateAdapter: DateAdapter<D>,
    @Inject(MAT_DATE_FORMATS) private _dateFormats: MatDateFormats,
    cdr: ChangeDetectorRef,
    private http: HttpClient
  ) {
    _calendar.stateChanges.pipe(takeUntil(this._destroyed)).subscribe(() => cdr.markForCheck());
  }

  ngOnDestroy() {
    this._destroyed.next();
    this._destroyed.complete();
  }





  public carrers: any;
  public genters: any;  
  public semesters: any;
  ngOnInit() {
    this.GetCatalogs();


  }
  get periodLabel() {
    return this._dateAdapter
      .format(this._calendar.activeDate, this._dateFormats.display.monthYearLabel)
      .toLocaleUpperCase();
  }

  previousClicked(mode: 'month' | 'year') {
    this._calendar.activeDate =
      mode === 'month'
        ? this._dateAdapter.addCalendarMonths(this._calendar.activeDate, -1)
        : this._dateAdapter.addCalendarYears(this._calendar.activeDate, -1);
  }

  nextClicked(mode: 'month' | 'year') {
    this._calendar.activeDate =
      mode === 'month'
        ? this._dateAdapter.addCalendarMonths(this._calendar.activeDate, 1)
        : this._dateAdapter.addCalendarYears(this._calendar.activeDate, 1);
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
