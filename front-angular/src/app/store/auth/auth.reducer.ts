import { createReducer, on } from '@ngrx/store';
import { clearAuthToken, setIsLogged } from './auth.actions';
import { Router } from '@angular/router';

export interface AuthState {
  isLogged: boolean;
}

export const initialState: AuthState = {
  isLogged: !!localStorage.getItem('token'),
};

export const authReducer = createReducer(
  initialState,
  on(clearAuthToken, (state) => {
    console.log('clearAuthToken action triggered');
    localStorage.removeItem('token');    
    return { ...state, isLogged: false };
  }),
  on(setIsLogged, (state, { isLogged }) => {
    console.log('setIsLogged action triggered with:', isLogged); 
    return { ...state, isLogged };
  })
);
