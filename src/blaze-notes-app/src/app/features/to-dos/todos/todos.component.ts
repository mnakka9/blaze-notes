import { Component, inject, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { first, map, Observable } from 'rxjs';
import { TodosState } from '../../../store/todos/todos-state';
import * as TodosActions from '../../../store/todos/todos-action';
import { ToDoTask } from '../../../api/models/to-do-task';
import { FormsModule } from '@angular/forms';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { selectFeatureTodos } from '../../../store/todos/todos-selector';
import { BlazeNotesApiService } from '../../../api/services/blaze-notes-api.service';
import { PriorityLevel } from '../../../api/models/priority-level';

@Component({
  selector: 'app-todos',
  standalone: true,
  imports: [FormsModule, NgFor, NgIf, CommonModule],
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.scss'],
})
export class TodosComponent implements OnInit {
  todos$: Observable<ToDoTask[]>;
  newTodoTitle: string = '';
  guid: string = '';
  private store: Store<TodosState> = inject(Store);

  constructor(private apiService: BlazeNotesApiService) {
    this.todos$ = this.store.select(selectFeatureTodos);
  }

  ngOnInit(): void {
    this.store.dispatch(TodosActions.loadTodos());
  }

  getListByGuid(): void {
    this.store.dispatch(TodosActions.loadTodosByGuid({ guid: this.guid }));
  }

  addTodo(): void {
    const newTodo: ToDoTask = {
      createdAt: new Date(Date.now()),
      title: this.newTodoTitle,
      isCompleted: false,
      priority: PriorityLevel.Medium,
    };
    this.store.dispatch(TodosActions.addTodo({ todo: newTodo }));
    this.newTodoTitle = '';
  }

  deleteTodo(todo: ToDoTask): void {
    this.store.dispatch(TodosActions.deleteTodo({ title: todo.title! }));
  }

  completeTodo(todo: ToDoTask): void {
    const updatedTodo = { ...todo, isCompleted: !todo.isCompleted };
    this.store.dispatch(TodosActions.updateTodo({ todo: updatedTodo }));
  }

  saveTodos(): void {
    this.todos$.pipe(first()).subscribe((todos) => {
      if (this.guid) {
        this.apiService.updateToDoListByGuid(this.guid, todos).subscribe();
      } else {
        this.apiService.addNewToDoList(todos).pipe(
          map((response) => {
            this.guid = response.listGuid;
          })
        ).subscribe();
      }
    });
  }

  resetPage(): void {
    window.location.reload();
  }
}
