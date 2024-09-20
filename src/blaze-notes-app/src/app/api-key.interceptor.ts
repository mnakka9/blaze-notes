import { HttpInterceptorFn } from '@angular/common/http';

export const ApiKeyInterceptor: HttpInterceptorFn = (req, next) => {
  const apiKey = 'mn-api-key-7893';

    const clonedRequest = req.clone({
      setHeaders: {
        'api-key': apiKey
      }
    });

  return next(clonedRequest);
};
