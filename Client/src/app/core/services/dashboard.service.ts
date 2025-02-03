import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;

  getSummary(): Observable<any> {
    return this.http.get(`${this.baseUrl}dashboard/summary`);
  }

  getDemographics(): Observable<any> {
    return this.http.get(`${this.baseUrl}dashboard/demographics`);
  }

  getRecentClients(): Observable<any> {
    return this.http.get(`${this.baseUrl}dashboard/recent-clients`);
  }
}