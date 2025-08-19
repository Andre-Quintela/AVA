import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginDto } from '../DTOs/LoginDto';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    private apiUrl = `${environment.apiUrl}/Login`;

    constructor(private http: HttpClient) {}

    login(loginDto: LoginDto): Observable<any> {
        return this.http.post<any>(`${this.apiUrl}/Login`, loginDto);
    }
}