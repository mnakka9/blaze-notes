import { createFeatureSelector, createSelector } from "@ngrx/store";
import { TodosState } from "./todos-state";

export const selectFeature = createFeatureSelector<TodosState>('todos');

export const selectFeatureTodos = createSelector(
    selectFeature,
    (state) => state.todos
);