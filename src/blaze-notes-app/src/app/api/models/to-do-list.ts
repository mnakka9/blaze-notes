import { ToDoTask } from "./to-do-task";

export interface ToDoList {
    listGuid: string;
    id: number;
    toDoTasks: ToDoTask[];
}