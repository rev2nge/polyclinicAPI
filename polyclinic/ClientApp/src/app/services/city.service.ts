import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { City } from '../city/City';

@Injectable({
    providedIn: 'root'
})
export class CityService {

  public baseApiUrl: string = environment.apiUrL

    constructor(private http: HttpClient) { }

    getAllCities(): Observable<string[]> {
        return this.http.get<string[]>(this.baseApiUrl + '/city/cities');
    }

  createCity(createCityRequest: City) {
    console.log(createCityRequest);
    const headers = new Headers({ 'Content-Type': 'application/json' });
    return this.http.post(this.baseApiUrl + '/city/CreateCity', createCityRequest).subscribe(data => console.log("data", data));
  }

    setPrimaryPhoto(propertyId: number, propertyPhotoId: string) {
        const httpOptions = {
            headers: new HttpHeaders({
                Authorization: 'Bearer '+ localStorage.getItem('token')
            })
        };
        return this.http.post(this.baseApiUrl + '/property/set-primary-photo/'+String(propertyId)
            +'/'+propertyPhotoId, {}, httpOptions);
    }

    deletePhoto(propertyId: number, propertyPhotoId: string) {
        const httpOptions = {
            headers: new HttpHeaders({
                Authorization: 'Bearer '+ localStorage.getItem('token')
            })
        };
        return this.http.delete(this.baseApiUrl + '/property/delete-photo/'
            +String(propertyId)+'/'+propertyPhotoId, httpOptions);
    }

}
