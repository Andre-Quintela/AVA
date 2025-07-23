import { ChangeDetectionStrategy, Component } from '@angular/core';
import { LoginService } from '../../core/Services/LoginService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginComponent { 
  constructor(private loginService: LoginService, private router: Router) {

  }

  email: string = '';
  senha: string = '';

  login() {
    const loginDto = {
      email: this.email,
      password: this.senha
    };
    this.loginService.login(loginDto).subscribe({
      next: (response) => {
        // console.log('Login realizado com sucesso', response);

        if(response) {
            localStorage.setItem('token', Math.random().toString(36).substring(2));
            this.router.navigate(['/home']);
        }

      },
      error: (error) => {
        console.error('Erro ao realizar login', error);
      }
    });
  }
}
