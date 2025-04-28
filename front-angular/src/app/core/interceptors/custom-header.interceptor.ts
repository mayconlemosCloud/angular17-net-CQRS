import { HttpEvent, HttpHandlerFn, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

export const customHeaderInterceptor: HttpInterceptorFn = (req: HttpRequest<any>, next: HttpHandlerFn): Observable<HttpEvent<any>> => {
  const modifiedReq = req.clone({
    setHeaders: {
      'authorization': `Bearer ${localStorage.getItem('token')}`
    }
  });
  return next(modifiedReq);
};
