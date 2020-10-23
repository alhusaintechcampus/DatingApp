import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }
// this request need authorized token to be done successfully, interceptor do that auto...
  getMembers ()
  {
    return this.http.get<Member[]>(this.baseUrl + 'users');
  }
// this request need authorized token to be done successfully, interceptor do that auto...
  getMember (username: string)
  {
    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }

}
