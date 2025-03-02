import {inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {member} from '../_models/member';
import {AccountService} from './account.service';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
    private readonly http = inject(HttpClient)
    private readonly accountServices = inject(AccountService)
    baseUrl = environment.apiUrl;

    getMembers() {
        return this.http.get<member[]>(this.baseUrl + 'users', this.getHttpOptions());
    }

    getMember(username: string) {
        return this.http.get<member>(this.baseUrl + 'users/' + username, this.getHttpOptions());
    }

    getHttpOptions() {
        return{
            headers: new HttpHeaders({
                authorization: `Bearer ${this.accountServices.currentUser()?.token}`
            })
        }
    }
}
