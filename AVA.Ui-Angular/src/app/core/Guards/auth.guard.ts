import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../Services/Auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const isLoggedIn = this.authService.isLoggedIn();
    const userRole = this.authService.getRole();
    const allowedRoles = route.data['roles'] as string[];

    if (!isLoggedIn) {
      // Usuário não está logado
      this.router.navigate(['/login']);
      return false;
    }

    if (allowedRoles && !allowedRoles.includes(userRole!)) {
      // Usuário logado mas sem permissão para a rota
      this.router.navigate(['/unauthorized']);
      return false;
    }

    return true; // Acesso permitido
  }
}
