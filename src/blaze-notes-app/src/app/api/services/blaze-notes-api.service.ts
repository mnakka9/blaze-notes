import { Injectable } from "@angular/core";
import { BaseService } from "../base-service";
import { HttpClient } from "@angular/common/http";
import { ApiConfiguration } from "../api-configuration";
import { ToDoTask } from "../models/to-do-task";
import { Observable } from "rxjs";
import { ToDoList } from "../models/to-do-list";


@Injectable({
  providedIn: 'root'
})
export class BlazeNotesApiService extends BaseService {
  private apiPathForSample = '/todos/sample';
  constructor(http: HttpClient, config: ApiConfiguration) {
    super(config, http);
  }

  sampleGet(): Observable<ToDoTask[]> {
    return this.http.get<ToDoTask[]>(`${this.rootUrl}${this.apiPathForSample}`);
  }

  getToDoListByGuid(guid: string) : Observable<ToDoList> {
    return this.http.get<ToDoList>(`${this.rootUrl}/todos/get/${guid}`);
  }

  updateToDoListByGuid(guid: string, tasks: ToDoTask[]) : Observable<ToDoList> {
    return this.http.put<ToDoList>(`${this.rootUrl}/todos/${guid}`, tasks);
  }

  addNewToDoList(tasks: ToDoTask[]) : Observable<ToDoList> {
    return this.http.post<ToDoList>(`${this.rootUrl}/todos`, tasks);
  }
}
