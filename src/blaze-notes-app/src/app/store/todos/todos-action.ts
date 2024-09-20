import { createAction, props } from '@ngrx/store';
import { ToDoTask } from '../../api/models/to-do-task';

export const loadTodos = createAction('[Todos] Load Todos');
export const loadTodosSuccess = createAction(
  '[Todos] Load Todos Success',
  props<{ todos: ToDoTask[] }>()
);
export const loadTodosFailure = createAction(
  '[Todos] Load Todos Failure',
  props<{ error: any }>()
);

export const addTodo = createAction(
  '[Todos] Add Todo',
  props<{ todo: ToDoTask }>()
);
export const updateTodo = createAction(
  '[Todos] Update Todo',
  props<{ todo: ToDoTask }>()
);
export const deleteTodo = createAction(
  '[Todos] Delete Todo',
  props<{ title: string }>()
);

export const loadTodosByGuid = createAction(
  '[Todos] Load Todos By Guid',
  props<{ guid: string }>()
);

export const loadTodosByGuidSuccess = createAction(
  '[Todos] Load Todos By Guid Success',
  props<{ todos: ToDoTask[] }>()
);

export const loadTodosByGuidFailure = createAction(
  '[Todos] Load Todos By Guid Failure',
  props<{ error: any }>()
);