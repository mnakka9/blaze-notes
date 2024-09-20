import { ToDoTask } from '../../api/models/to-do-task';

export interface TodosState {
  todos: ToDoTask[];
  loading: boolean;
  error: any;
}

export const initialState: TodosState = {
  todos: [],
  loading: false,
  error: null,
};