import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  url = 'https://localhost:44366/usuarios';

  constructor(private http: HttpClient) {}

  getUsers() {
    return this.http.get<[]>(this.url);
  }

  
}
