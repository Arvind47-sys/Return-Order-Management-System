import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastr: ToastrService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError(error => {
        if (error) {
          switch (error.status) {
            case 400:
              var err = error.error.errors;
              if (err) {
                const modalStatusErrors = [];
                for (const key in err) {
                  if (err[key]) {
                    modalStatusErrors.push(err[key]);
                  }
                }
                modalStatusErrors.forEach(err => {
                  this.toastr.error(err);
                })
                throw modalStatusErrors.flat();
              }
              else
                this.toastr.error('Bad Request');
              break;

            case 401:
              this.toastr.error('Unauthorized');
              break;

            case 404:
              this.router.navigateByUrl('/not-found');
              break;

            case 500:
              const navigationExtras: NavigationExtras = { state: { error: error.error } };
              console.log(error);
              this.router.navigateByUrl('/server-error', navigationExtras);
              break;

            default:
              this.toastr.error('Something unexpected went wrong');
              console.log(error);
              break;
          }
        }
        return throwError(error);
      })
    )
  }
}
