import { ChangeDetectionStrategy, Component } from '@angular/core';
import { LoginService } from '../../core/services/LoginService';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [CommonModule,FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoginComponent { 
  constructor(private loginService: LoginService) {
    
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
        console.log('Login realizado com sucesso', response);
      },
      error: (error) => {
        console.error('Erro ao realizar login', error);
      }
    });
  }
}
