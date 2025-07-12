import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDto } from '../DTOs/UserDto';
import { environment } from '../../environments/environment';


@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiUrl = `${environment.apiUrl}/User`;

    constructor(private http: HttpClient) {}

    getAll(): Observable<any> {
        return this.http.get(`${this.apiUrl}/GetAll`);
    }

    create(userDto: UserDto): Observable<any> {
        return this.http.post(`${this.apiUrl}/Create`, userDto);
    }
}