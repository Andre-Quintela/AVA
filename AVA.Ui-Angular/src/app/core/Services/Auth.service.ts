import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly TOKEN_KEY = 'token';
  private readonly ROLE_KEY = 'userRole';

  // Salvar token e role no localStorage
  setSession(token: string, role: string) {
    localStorage.setItem(this.TOKEN_KEY, token);
    localStorage.setItem(this.ROLE_KEY, role);
  }

  // Obter token salvo
  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  // Obter role salva
  getRole(): string | null {
    return localStorage.getItem(this.ROLE_KEY);
  }

  // Verifica se o usuário está logado
  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  // Limpar sessão
  logout() {
    localStorage.removeItem(this.TOKEN_KEY);
    localStorage.removeItem(this.ROLE_KEY);
  }
}
