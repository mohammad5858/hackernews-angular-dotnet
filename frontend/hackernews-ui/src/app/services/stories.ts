import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Story {
  id: number;
  title: string;
  url?: string;
  by: string;
  score: number;
  time: number;
}

@Injectable({
  providedIn: 'root',
})
export class StoriesService {
  private apiUrl = 'http://localhost:5196/api/stories';

  constructor(private http: HttpClient) { }

  getStories(page: number = 1, pageSize: number = 20, search: string = ''): Observable<Story[]> {
    let params = new HttpParams()
      .set('page', page)
      .set('pageSize', pageSize);
    if (search) {
      params = params.set('search', search);
    }
    return this.http.get<Story[]>(this.apiUrl, { params });
  }
}
