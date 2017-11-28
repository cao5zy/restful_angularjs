import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import { Injectable } from '@angular/core';
@Injectable()
export abstract class Service{
    abstract get(urn: string, param: any): Observable<any>;
    abstract post(urn: string, param: any): Observable<any>;
    abstract put(urn: string, param: any): Observable<any>;
    abstract delete(urn: string, param: any): Observable<any>;
}