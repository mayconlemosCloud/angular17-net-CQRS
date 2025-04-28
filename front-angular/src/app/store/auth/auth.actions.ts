import { createAction, props } from '@ngrx/store';

export const clearAuthToken = createAction('[Auth] Clear Auth Token');

export const setIsLogged = createAction(
  '[Auth] Set Is Logged',
  props<{ isLogged: boolean }>()
);
