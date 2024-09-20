import { inject, Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, mergeMap } from 'rxjs/operators';
import * as TodosActions from './todos-action';
import { BlazeNotesApiService } from '../../api/services/blaze-notes-api.service';
import { ToDoTask } from '../../api/models/to-do-task';

@Injectable()
export class TodosEffects {
  private actions$ = inject(Actions);
  constructor(
    private apiService: BlazeNotesApiService
  ) {
    //console.log(this.actions$);
  }

  loadTodos$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TodosActions.loadTodos),
      mergeMap(() =>
        this.apiService.sampleGet().pipe(
          map((todos: ToDoTask[]) =>
            TodosActions.loadTodosSuccess({ todos: todos })
          ),
          catchError((error) => of(TodosActions.loadTodosFailure({ error })))
        )
      )
    )
  );

  loadTodosByGuid$ = createEffect(() =>
    this.actions$.pipe(
      ofType(TodosActions.loadTodosByGuid),
      mergeMap(({ guid }) =>
        this.apiService.getToDoListByGuid(guid).pipe(
          map((todoList) => TodosActions.loadTodosByGuidSuccess({ todos: todoList.toDoTasks })),
          catchError((error) => of(TodosActions.loadTodosByGuidFailure({ error })))
        )
      )
    )
  );
}
