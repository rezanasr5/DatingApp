import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private readonly http = inject(HttpClient);
  baseUrl = 'https://localhost:5001/api/';

  login(model: any) {
    return this.http.post(this.baseUrl + 'account/login', model);
  }
}
