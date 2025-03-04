import {inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {member} from '../_models/member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
    private readonly http = inject(HttpClient)
    baseUrl = environment.apiUrl;

    getMembers() {
        return this.http.get<member[]>(this.baseUrl + 'users');
    }

    getMember(username: string) {
        return this.http.get<member>(this.baseUrl + 'users/' + username);
    }

    updateMember(member: member){
        return this.http.put(this.baseUrl + 'users', member);
    }


}
