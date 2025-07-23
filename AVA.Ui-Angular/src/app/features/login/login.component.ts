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
        localStorage.setItem('token', response.token);
        localStorage.setItem('role', response.role);
        this.router.navigate(['/home']);
      },
      error: (err) => {
        if (err.status === 401) {
          alert('Usuário ou senha inválidos');
        } else {
          alert('Erro inesperado. Tente novamente.');
        }
      }
    });
  }
}
