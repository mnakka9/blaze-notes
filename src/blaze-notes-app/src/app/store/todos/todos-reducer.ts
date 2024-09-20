import { createReducer, on } from '@ngrx/store';
import * as TodosActions from './todos-action';
import { TodosState, initialState } from './todos-state';

export const todosReducer = createReducer(
  initialState,
  on(TodosActions.loadTodos, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(TodosActions.loadTodosSuccess, (state, { todos }) => ({
    ...state,
    todos,
    loading: false,
    error: null,
  })),
  on(TodosActions.loadTodosFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error,
  })),
  on(TodosActions.addTodo, (state, { todo }) => ({
    ...state,
    todos: [...state.todos, todo]
  })),
  on(TodosActions.updateTodo, (state, { todo }) => ({
    ...state,
    todos: state.todos.map(t => t.title === todo.title ? todo : t)
  })),
  on(TodosActions.deleteTodo, (state, { title }) => ({
    ...state,
    todos: state.todos.filter(t => t.title !== title)
  })),
  on(TodosActions.loadTodosByGuid, (state) => ({
    ...state,
    loading: true,
    error: null,
  })),
  on(TodosActions.loadTodosByGuidSuccess, (state, { todos }) => ({
    ...state,
    todos,
    loading: false,
    error: null,
  })),
  on(TodosActions.loadTodosByGuidFailure, (state, {error}) => ({
    ...state,
    loading: false,
    error,
  })),
);