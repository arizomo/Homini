import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from "@angular/http";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class DepartamentoService {

  constructor(private http: Http) { }

  public GetDepartamentoAll() {
    let fullUrl = 'https://localhost:44339/api/v1/Departamentos/GetDepartamentoAll';
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));;
  }

  public InsertDepartamento(IDEPT) {
    let fullUrl = "https://localhost:44339/api/v1/Departamentos/InsertDepartamento";
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.post(fullUrl, JSON.stringify(IDEPT), options).pipe(map(result => result.json()));
  }

  public UpdateDepartamento(UDEPT) {
    let fullUrl = "https://localhost:44339/api/v1/Departamentos/UpdateDepartamento";
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.put(fullUrl, JSON.stringify(UDEPT), options).pipe(map(result => result.json()));
  }

  public DeleteDepartamento(DELEDEPT) {
    let fullUrl = "https://localhost:44339/api/v1/Departamentos/DeleteDepartamento/" + DELEDEPT;
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.delete(fullUrl, options).pipe(map(result => result.json()));
  }
}
